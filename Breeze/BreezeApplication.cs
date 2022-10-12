using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Breeze
{
	public partial class Breeze : Form
	{
		public Breeze() {
				InitializeComponent();
		}

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

		//EXIT
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

		private Color expandMinimiseDefaultColor = Color.FromArgb(255, 28, 37, 65);
		private Color expandMinimiseHoverColor = Color.FromArgb(255, 48, 57, 85);
				
		//EXPAND
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

		//MINIMISE
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

		private void Breeze_Load(object sender, EventArgs e)
		{
			this.FormBorderStyle = FormBorderStyle.None;
		}
	}
}
