using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

				//Form exit, expand, minimise buttons
				private Color titleDefaultColor = Color.FromArgb(255, 28, 37, 65);
				private Color titleHoverColor = Color.Red;

				private void exitButton_MouseDown(object sender, MouseEventArgs e) => this.Close();

				private void exitButton_MouseEnter(object sender, System.EventArgs e)
				{
						this.exitButton.BackColor = titleHoverColor;
				}

				private void exitButton_MouseLeave(object sender, System.EventArgs e)
				{
						this.exitButton.BackColor = titleDefaultColor;
				}
				#endregion

				private void Breeze_Load(object sender, EventArgs e)
				{

				}
		}
}
