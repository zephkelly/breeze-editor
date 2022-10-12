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

				/// <summary>
				/// Required method for Designer support - do not modify
				/// the contents of this method with the code editor.
				/// </summary>
				private void InitializeComponent()
				{
						this.components = new System.ComponentModel.Container();
						this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
						this.TitleBar = new System.Windows.Forms.Panel();
						this.tabIcon = new System.Windows.Forms.PageSetupDialog();
						this.expandIcon = new System.Windows.Forms.Panel();
						this.exitButton = new System.Windows.Forms.Panel();
						this.Icon = new System.Windows.Forms.PictureBox();
						this.minimiseIcon = new System.Windows.Forms.Panel();
						this.TitleBar.SuspendLayout();
						((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
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
						this.TitleBar.Controls.Add(this.minimiseIcon);
						this.TitleBar.Controls.Add(this.expandIcon);
						this.TitleBar.Controls.Add(this.exitButton);
						this.TitleBar.Controls.Add(this.Icon);
						this.TitleBar.Location = new System.Drawing.Point(0, 0);
						this.TitleBar.Name = "TitleBar";
						this.TitleBar.Size = new System.Drawing.Size(1400, 35);
						this.TitleBar.TabIndex = 1;
						this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
						this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
						this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
						// 
						// expandIcon
						// 
						this.expandIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
						this.expandIcon.BackgroundImage = global::Breeze.Properties.Resources.expandIcon;
						this.expandIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
						this.expandIcon.Location = new System.Drawing.Point(1310, 0);
						this.expandIcon.Name = "expandIcon";
						this.expandIcon.Size = new System.Drawing.Size(45, 35);
						this.expandIcon.TabIndex = 3;
						// 
						// exitButton
						// 
						this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
						this.exitButton.BackgroundImage = global::Breeze.Properties.Resources.exitIcon;
						this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
						this.exitButton.Location = new System.Drawing.Point(1355, 0);
						this.exitButton.Name = "exitButton";
						this.exitButton.Size = new System.Drawing.Size(45, 35);
						this.exitButton.TabIndex = 2;
						this.exitButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.exitButton_MouseDown);
						this.exitButton.MouseEnter += new System.EventHandler(this.exitButton_MouseEnter);
						this.exitButton.MouseLeave += new System.EventHandler(this.exitButton_MouseLeave);
						// 
						// Icon
						// 
						this.Icon.Image = global::Breeze.Properties.Resources.icon;
						this.Icon.Location = new System.Drawing.Point(6, 6);
						this.Icon.Name = "Icon";
						this.Icon.Size = new System.Drawing.Size(24, 24);
						this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
						this.Icon.TabIndex = 2;
						this.Icon.TabStop = false;
						// 
						// minimiseIcon
						// 
						this.minimiseIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
						this.minimiseIcon.BackgroundImage = global::Breeze.Properties.Resources.minimiseIcon;
						this.minimiseIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
						this.minimiseIcon.Location = new System.Drawing.Point(1265, 0);
						this.minimiseIcon.Name = "minimiseIcon";
						this.minimiseIcon.Size = new System.Drawing.Size(45, 35);
						this.minimiseIcon.TabIndex = 4;
						// 
						// Breeze
						// 
						this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
						this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
						this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(19)))), ((int)(((byte)(43)))));
						this.ClientSize = new System.Drawing.Size(1400, 800);
						this.ControlBox = false;
						this.Controls.Add(this.TitleBar);
						this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
						this.Name = "Breeze";
						this.Load += new System.EventHandler(this.Breeze_Load);
						this.TitleBar.ResumeLayout(false);
						((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
						this.ResumeLayout(false);

				}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Panel TitleBar;
				private System.Windows.Forms.PictureBox Icon;
				private System.Windows.Forms.PageSetupDialog tabIcon;
				private System.Windows.Forms.Panel expandIcon;
				private System.Windows.Forms.Panel exitButton;
				private System.Windows.Forms.Panel minimiseIcon;
		}
}

