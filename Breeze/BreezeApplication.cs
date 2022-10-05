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

				Point cursorInitialPoint = Point.Empty;
				bool canDrag = false;

				private void TitleBar_MouseDown(object sender, MouseEventArgs e)
				{
						canDrag = true;
						cursorInitialPoint = e.Location;
				}

				private void TitleBar_MouseUp(object sender, MouseEventArgs e)
				{
						canDrag = false;
				}

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
		}
}
