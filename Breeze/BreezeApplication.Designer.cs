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
						this.TitleBar.Location = new System.Drawing.Point(0, 0);
						this.TitleBar.Name = "TitleBar";
						this.TitleBar.Size = new System.Drawing.Size(1400, 35);
						this.TitleBar.TabIndex = 1;
						this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
						this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
						this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
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
						this.ResumeLayout(false);

				}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Panel TitleBar;
	}
}

