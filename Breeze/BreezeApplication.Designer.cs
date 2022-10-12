namespace Breeze
{
		partial class Breeze
		{
			/// <summary>
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.IContainer components = null;

			/// <summary>
			/// Clean up any resources being used.
			/// </summary>
			/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
			protected override void Dispose(bool disposing)
			{
				if (disposing && (components != null))
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}

			#region Windows Form Designer generated code
			private void InitializeComponent()
			{
			this.components = new System.ComponentModel.Container();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.TitleBar = new System.Windows.Forms.Panel();
			this.minimiseButton = new System.Windows.Forms.Panel();
			this.expandButton = new System.Windows.Forms.Panel();
			this.exitButton = new System.Windows.Forms.Panel();
			this.icon = new System.Windows.Forms.PictureBox();
			this.TitleBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
			// 
			// TitleBar
			// 
			this.TitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
			this.TitleBar.Controls.Add(this.minimiseButton);
			this.TitleBar.Controls.Add(this.expandButton);
			this.TitleBar.Controls.Add(this.exitButton);
			this.TitleBar.Controls.Add(this.icon);
			this.TitleBar.Location = new System.Drawing.Point(0, 0);
			this.TitleBar.Name = "TitleBar";
			this.TitleBar.Size = new System.Drawing.Size(1000, 35);
			this.TitleBar.TabIndex = 1;
			this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
			this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
			this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
			// 
			// minimiseButton
			// 
			this.minimiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.minimiseButton.BackgroundImage = global::Breeze.Properties.Resources.minimiseIcon;
			this.minimiseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.minimiseButton.Location = new System.Drawing.Point(865, 0);
			this.minimiseButton.Name = "minimiseButton";
			this.minimiseButton.Size = new System.Drawing.Size(45, 35);
			this.minimiseButton.TabIndex = 4;
			this.minimiseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MinimiseButton_MouseDown);
			this.minimiseButton.MouseEnter += new System.EventHandler(this.MinimiseButton_MouseEnter);
			this.minimiseButton.MouseLeave += new System.EventHandler(this.MinimiseButton_MouseExit);
			// 
			// expandButton
			// 
			this.expandButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.expandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
			this.expandButton.BackgroundImage = global::Breeze.Properties.Resources.expandIcon;
			this.expandButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.expandButton.Location = new System.Drawing.Point(910, 0);
			this.expandButton.Name = "expandButton";
			this.expandButton.Size = new System.Drawing.Size(45, 35);
			this.expandButton.TabIndex = 3;
			this.expandButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExpandButton_MouseDown);
			this.expandButton.MouseEnter += new System.EventHandler(this.ExpandButton_MouseEnter);
			this.expandButton.MouseLeave += new System.EventHandler(this.ExpandButton_MouseExit);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.exitButton.BackgroundImage = global::Breeze.Properties.Resources.exitIcon;
			this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.exitButton.Location = new System.Drawing.Point(955, 0);
			this.exitButton.Name = "exitButton";
			this.exitButton.Size = new System.Drawing.Size(45, 35);
			this.exitButton.TabIndex = 2;
			this.exitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExitButton_MouseDown);
			this.exitButton.MouseEnter += new System.EventHandler(this.ExitButton_MouseEnter);
			this.exitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
			// 
			// icon
			// 
			this.icon.Image = global::Breeze.Properties.Resources.icon;
			this.icon.Location = new System.Drawing.Point(6, 6);
			this.icon.Name = "icon";
			this.icon.Size = new System.Drawing.Size(24, 24);
			this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.icon.TabIndex = 2;
			this.icon.TabStop = false;
			// 
			// Breeze
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(19)))), ((int)(((byte)(43)))));
			this.ClientSize = new System.Drawing.Size(1000, 600);
			this.ControlBox = false;
			this.Controls.Add(this.TitleBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Breeze";
			this.Load += new System.EventHandler(this.Breeze_Load);
			this.TitleBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
			this.ResumeLayout(false);

			}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Panel TitleBar;
		    private System.Windows.Forms.PictureBox icon;
		    private System.Windows.Forms.Panel expandButton;
		    private System.Windows.Forms.Panel exitButton;
		    private System.Windows.Forms.Panel minimiseButton;
		}
}

