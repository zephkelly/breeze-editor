using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Breeze
{
	public partial class Breeze : Form
	{
		public Breeze()
		{
			InitializeComponent();

			this.DoubleBuffered = true;
			this.FormBorderStyle = FormBorderStyle.None;
			this.SetStyle(ControlStyles.ResizeRedraw, true);

			initialCharacterColour = Color.FromArgb(235, 235, 235);

			ChangeTabsWidth(2);
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
		Color initialCharacterColour = new Color();

		//Expression patterns
		string keywords = @"\b(public|private|partial|static|void|class|namespace|interface|enum|using|foreach|in|if|else|do|while)\b";
		string variables = @"\b(var|const|int|string|long|bool|float|char|this)\b";
		string comments = @"(/\*[^*]*\*+(?:[^/*][^*]*\*+)*/|\/\/.+?$)";
		string types = @"\b(Console)\b";
		string strings = "\".+?\"";

		private void MainEditorBox_TextChanged(object sender, EventArgs e)
		{
			mainEditorBox.ForeColor = Color.White;

			//Character collections
			MatchCollection keywordMatches = Regex.Matches(mainEditorBox.Text, keywords);
			MatchCollection variableMatches = Regex.Matches(mainEditorBox.Text, variables);
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

			//UpdateLineLength(); //incase line char index is -1

			Console.WriteLine(displayedTopline);

			lineNumberBox.SelectionStart = lineNumberBox.GetFirstCharIndexFromLine(displayedTopline);
			lineNumberBox.ScrollToCaret();
		}
		#endregion

		#region Tabs settings
		public void ChangeTabsWidth(int newWidth)
		{
			switch (newWidth)
			{
				case 1:
					mainEditorBox.SelectionTabs = new int[] { 20 };
					break;
				case 2:
					mainEditorBox.SelectionTabs = new int[] { 20, 40 };
					break;
				case 3:
					mainEditorBox.SelectionTabs = new int[] { 20, 40, 60 };
					break;
				case 4:
					mainEditorBox.SelectionTabs = new int[] { 20, 40, 60, 80 };
					break;
				default:
					Console.WriteLine("Error, tabs width not supported. Setting tab size to 2");
					mainEditorBox.SelectionTabs = new int[] { 20 };
					break;
			}
		}
		#endregion
	}
}   
