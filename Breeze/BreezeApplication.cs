using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace Breeze
{
	public partial class Breeze : Form
	{
		public Breeze()
		{
			InitializeComponent();
			this.SetStyle(ControlStyles.ResizeRedraw, true);

			ChangeTabsWidth(2);
			PopulateTreeView("C:\\development");

			//Focus on our editor box on start
			this.ActiveControl = mainEditorBox;
		}

		#region Resizable Form
		private const int gripSize = 12;
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x84)
			{
				Point cursorPoint = new Point(m.LParam.ToInt32());
				cursorPoint = this.PointToClient(cursorPoint);
				//Pointer bottom resizeable
				if (cursorPoint.Y >= this.ClientSize.Height - gripSize && cursorPoint.X <= this.ClientSize.Width - gripSize)
				{
					m.Result = (IntPtr)15;
					return;
				}
				//Pointer right resizable
				if (cursorPoint.X >= this.ClientSize.Width - gripSize && cursorPoint.Y <= this.ClientSize.Height - gripSize)
				{
					m.Result = (IntPtr)11;
					return;
				}

				//Pointer resize bottom right corner
				if (cursorPoint.X >= this.ClientSize.Width - gripSize && cursorPoint.Y >= this.ClientSize.Height - gripSize)
				{
					m.Result = (IntPtr)17;
					return;
				}

				//Standard pointer behaviour
				if (cursorPoint.Y <= this.ClientSize.Height - gripSize)
				{
					m.Result = (IntPtr)1;
					return;
				}
			}

			if (m.Msg == WM_MOUSEWHEEL)
			{
				int scrollLines = SystemInformation.MouseWheelScrollLines;
				for (int i = 0; i < scrollLines; i++)
				{
					if ((int)m.WParam > 0)
					{
						SendMessage(this.Handle, WM_VSCROLL, (IntPtr)0, IntPtr.Zero); // scroll up
					}
					else
					{
						SendMessage(this.Handle, WM_VSCROLL, (IntPtr)1, IntPtr.Zero); // else scroll down
					}
				}
				return;
			}
			base.WndProc(ref m);
		}
		#endregion

		#region Title bar
		Point cursorInitialPoint = Point.Empty;
		bool canDrag = false;

		//Titlebar main behaviour
		private void TitleBar_MouseDown(object sender, MouseEventArgs e)
		{
			canDrag = true;
			cursorInitialPoint = e.Location;
		}

		private void TitleBar_MouseUp(object sender, MouseEventArgs e) => canDrag = false;

		private void TitleBar_MouseMove(object sender, MouseEventArgs e)
		{
			if (canDrag == false) return;

			Vector2 currentCursorPosition = new Vector2(
				Cursor.Position.X,
				Cursor.Position.Y
			);

			Vector2 cursorOffset = new Vector2(
				cursorInitialPoint.X,
				cursorInitialPoint.Y
			);

			Point newFormLocation = new Point(
				(int)(currentCursorPosition.X - cursorOffset.X),
				(int)(currentCursorPosition.Y - cursorOffset.Y)
			);

			this.Location = newFormLocation;
		}

		#region EXIT BUTTON
		private Color titleDefaultColor = Color.FromArgb(255, 28, 37, 65);
		private Color titleHoverColor = Color.Red;

		private void ExitButton_MouseDown(object sender, MouseEventArgs e) => this.Close();

		private void ExitButton_MouseEnter(object sender, System.EventArgs e)
		{
			this.exitButton.BackColor = titleHoverColor;
		}

		private void ExitButton_MouseLeave(object sender, System.EventArgs e)
		{
			this.exitButton.BackColor = titleDefaultColor;
		}
		#endregion

		private Color expandMinimiseDefaultColor = Color.FromArgb(255, 28, 37, 65);
		private Color expandMinimiseHoverColor = Color.FromArgb(255, 48, 57, 85);

		#region EXPAND BUTTON
		private Vector2 unexpandedFormSize = Vector2.Zero;
		private bool isExpanded = false;

		private void ExpandButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (isExpanded)
			{
				this.Width = (int)unexpandedFormSize.X;
				this.Height = (int)unexpandedFormSize.Y;

				this.TopMost = false;
				this.WindowState = FormWindowState.Normal;
			}
			else
			{
				unexpandedFormSize.X = this.Width;
				unexpandedFormSize.Y = this.Height;

				this.TopMost = true;
				this.WindowState = FormWindowState.Maximized;
			}

			isExpanded = !isExpanded;
		}

		private void ExpandButton_MouseEnter(object sender, System.EventArgs e)
		{
			this.expandButton.BackColor = expandMinimiseHoverColor;
		}
	
		private void ExpandButton_MouseExit(object sender, System.EventArgs e)
		{
			this.expandButton.BackColor = expandMinimiseDefaultColor;
		}
		#endregion

		#region MINIMISE BUTTON
		private void MinimiseButton_MouseDown(object sender, MouseEventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void MinimiseButton_MouseEnter(object sender, System.EventArgs e)
		{
			this.minimiseButton.BackColor = expandMinimiseHoverColor;
		}
		
		private void MinimiseButton_MouseExit(object sender, System.EventArgs e)
		{
			this.minimiseButton.BackColor = expandMinimiseDefaultColor;
		}
		#endregion
		#endregion

		#region Syntax Highlighting
		Color initialCharacterColour = Color.FromArgb(235, 235, 235);

		//Expression patterns
		string keywords = @"\b(public|private|partial|static|void|class|namespace|interface|enum|using|foreach|in|if|else|do|while|internal|get|set|return)\b";

		string variables = @"\b(var|const|int|string|long|bool|float|char|this|null|false|true|value|new)\b";

		string referenceTypes = @"\b(Dictionary|List|Vector2|Vector3|StringBuilder|Vector2Int|GameObject|Bounds)\b";

		string comments = @"(/\*[^*]*\*+(?:[^/*][^*]*\*+)*/|\/\/.+?$)";

		string types = @"\b(Console)\b";

		string strings = "\".+?\"";

		private void MainEditorBox_TextChanged(object sender, EventArgs e)
		{
			mainEditorBox.ForeColor = Color.White;

			//Character collections
			MatchCollection keywordMatches = Regex.Matches(mainEditorBox.Text, keywords);
			MatchCollection variableMatches = Regex.Matches(mainEditorBox.Text, variables);
			MatchCollection referenceTypesMatches = Regex.Matches(mainEditorBox.Text, referenceTypes);
			MatchCollection stringsMatches = Regex.Matches(mainEditorBox.Text, strings);
			MatchCollection commentMatches = Regex.Matches(mainEditorBox.Text, comments, RegexOptions.Multiline);
			MatchCollection typeMatches = Regex.Matches(mainEditorBox.Text, types);

			//Inital properties
			int initialIndex = mainEditorBox.SelectionStart;
			int initalLength = mainEditorBox.SelectionLength;

			//Blinking workaround, focus label
			editorBoxFocusLabel.Focus();

			//Set editor box properties
			mainEditorBox.SelectionStart = 0;
			mainEditorBox.SelectionLength = mainEditorBox.Text.Length;

			//Scanning characters
			foreach (Match match in keywordMatches) {
				mainEditorBox.SelectionStart = match.Index;
				mainEditorBox.SelectionLength = match.Length;
				mainEditorBox.SelectionColor = Color.Cyan;
			}

			foreach (Match match in variableMatches) {
				mainEditorBox.SelectionStart = match.Index;
				mainEditorBox.SelectionLength = match.Length;
				mainEditorBox.SelectionColor = Color.LightCoral;
			}

			foreach (Match match in referenceTypesMatches) {
				mainEditorBox.SelectionStart = match.Index;
				mainEditorBox.SelectionLength = match.Length;
				mainEditorBox.SelectionColor = Color.LightCoral;
			}

			foreach (Match match in commentMatches) {
				mainEditorBox.SelectionStart = match.Index;
				mainEditorBox.SelectionLength = match.Length;
				mainEditorBox.SelectionColor = Color.Green;
			}

			foreach (Match match in typeMatches) {
				mainEditorBox.SelectionStart = match.Index;
				mainEditorBox.SelectionLength = match.Length;
				mainEditorBox.SelectionColor = Color.Brown;
			}

			foreach (Match match in stringsMatches) {
				mainEditorBox.SelectionStart = match.Index;
				mainEditorBox.SelectionLength = match.Length;
				mainEditorBox.SelectionColor = Color.Green;
			}

			mainEditorBox.SelectionStart = initialIndex;
			mainEditorBox.SelectionLength = initalLength;
			mainEditorBox.SelectionColor = initialCharacterColour;

			//Refocus editorbox
			mainEditorBox.Focus();

			UpdateLineLength();
		}
		#endregion

		#region Line count
		StringBuilder lineCountBuilder = new StringBuilder(100);
		private void UpdateLineLength()
		{
			lineCountBuilder.Clear();

			if (mainEditorBox.Lines.Count() <= 0)
			{
				lineNumberBox.Text = "1";
				return;
			}

			int lineCount = mainEditorBox.Lines.Count();

			for (int i = 0; i < lineCount; i++)
			{
				lineCountBuilder.AppendLine((i+1).ToString());
			}

			lineNumberBox.Text = lineCountBuilder.ToString();
			UpdateLineNumberScrolling();
		}
		#endregion

		#region Line count scrolling
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

		private const int WM_MOUSEWHEEL = 0x20A;
		private const int WM_VSCROLL = 0x115;

		private void MainEditor_VerticalChanged(object sender, EventArgs e)
		{
			UpdateLineNumberScrolling();
		}

		private void UpdateLineNumberScrolling()
		{
			int topCharIndex = mainEditorBox.GetCharIndexFromPosition(new Point(0, 10));

			int bottomCharIndex = mainEditorBox.GetCharIndexFromPosition(new Point(
				mainEditorBox.ClientSize.Width,
				mainEditorBox.ClientSize.Height
			));

			int displayedTopline = mainEditorBox.GetLineFromCharIndex(topCharIndex);

			lineNumberBox.SelectionStart = lineNumberBox.GetFirstCharIndexFromLine(displayedTopline);
			lineNumberBox.ScrollToCaret();
		}
		#endregion

		#region Tabs settings
		public void ChangeTabsWidth(int tabSpacing)
		{
			int[] selectionWidths = new int[30];
			int currentSelectionTabWidth = 0;

			for (int i = 0; i < 30; i++)
			{
				currentSelectionTabWidth += (10 * tabSpacing);
				selectionWidths[i] = currentSelectionTabWidth;
			}

			mainEditorBox.SelectionTabs = selectionWidths;
		}
		#endregion

		#region Tree/list views
		private void PopulateTreeView(string directory)
		{
			TreeNode rootNode;

			DirectoryInfo info = new DirectoryInfo(directory);
			if (info.Exists)
			{
				rootNode = new TreeNode(info.Name);
				rootNode.Tag = info;
				GetDirectories(info.GetDirectories(), rootNode);
				treeView.Nodes.Add(rootNode);
			}
		}

		private void GetDirectories(DirectoryInfo[] subDirs,
				TreeNode nodeToAddTo)
		{
			TreeNode aNode;
			DirectoryInfo[] subSubDirs;
			foreach (DirectoryInfo subDir in subDirs)
			{
				aNode = new TreeNode(subDir.Name, 0, 0);
				aNode.Tag = subDir;
				aNode.ImageKey = "folder";

				//Exception handling
				try
				{
					subSubDirs = subDir.GetDirectories();
				}
				catch (UnauthorizedAccessException ex)
				{
					continue;
				}
				catch (DirectoryNotFoundException ex)
				{
					continue;
				}
				
				if (subSubDirs.Length != 0)
				{
					GetDirectories(subSubDirs, aNode);
				}
				nodeToAddTo.Nodes.Add(aNode);
			}
		}

		//Click on treeview behaviour
		private void TreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			TreeNode newSelected = e.Node;

			listView.Items.Clear();

			DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;

			ListViewItem.ListViewSubItem[] subItems;
			ListViewItem item = null;

			//Populate directories
			foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
			{
				item = new ListViewItem(dir.Name, 0);
				item.Name = dir.FullName;
				item.Tag = "folder";

				subItems = new ListViewItem.ListViewSubItem[] {
					new ListViewItem.ListViewSubItem(item, "Directory"),
					new ListViewItem.ListViewSubItem(item,
					dir.LastAccessTime.ToShortDateString())
				};

				item.SubItems.AddRange(subItems);
			}

			//Populate files
			foreach (FileInfo file in nodeDirInfo.GetFiles())
			{
				item = new ListViewItem(file.Name, 1);
				item.Name = file.FullName;
				item.Tag = "file";

				subItems = new ListViewItem.ListViewSubItem[] {
					new ListViewItem.ListViewSubItem(item, "File"),
					new ListViewItem.ListViewSubItem(item,
					file.LastAccessTime.ToShortDateString())
				};

				item.SubItems.AddRange(subItems);
				listView.Items.Add(item);
			}
		}
		#endregion

		#region Read to textbox/Save to file
		private ListViewItem currentlyActiveFile;
		private void ListView_ItemChosen(object sender, EventArgs e)
		{
			currentlyActiveFile = GetItemFromPoint(listView, Cursor.Position);

			string itemPath = Path.GetFullPath(currentlyActiveFile.Name).ToString();

			mainEditorBox.Text = System.IO.File.ReadAllText(itemPath);
		}

		private ListViewItem GetItemFromPoint(ListView listView, Point mousePosition)
		{
			Point localPoint = listView.PointToClient(mousePosition);
			return listView.GetItemAt(localPoint.X, localPoint.Y);
		}

		//Ctrl+S shortcut
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (keyData == (Keys.Control | Keys.S))
			{
				if (currentlyActiveFile == null) return true;

				mainEditorBox.SaveFile(currentlyActiveFile.Name, RichTextBoxStreamType.PlainText);

				MessageBox.Show("Your file was saved.");
				return true;
			}
			return base.ProcessCmdKey(ref msg, keyData);
		}

		//Add a file->save
		#endregion
	}
}   