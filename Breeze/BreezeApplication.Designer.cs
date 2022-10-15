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
			this.TitleBar = new System.Windows.Forms.Panel();
			this.titleLabel = new System.Windows.Forms.Label();
			this.minimiseButton = new System.Windows.Forms.Panel();
			this.expandButton = new System.Windows.Forms.Panel();
			this.exitButton = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.mainEditorBox = new System.Windows.Forms.RichTextBox();
			this.editorBoxFocusLabel = new System.Windows.Forms.Label();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.numberLineLable = new System.Windows.Forms.Label();
			this.lineNumberBox = new System.Windows.Forms.RichTextBox();
			this.TitleBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// TitleBar
			// 
			this.TitleBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
			this.TitleBar.Controls.Add(this.titleLabel);
			this.TitleBar.Controls.Add(this.minimiseButton);
			this.TitleBar.Controls.Add(this.expandButton);
			this.TitleBar.Controls.Add(this.exitButton);
			this.TitleBar.Controls.Add(this.pictureBox1);
			this.TitleBar.Location = new System.Drawing.Point(0, 0);
			this.TitleBar.Name = "TitleBar";
			this.TitleBar.Size = new System.Drawing.Size(1000, 35);
			this.TitleBar.TabIndex = 1;
			this.TitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseDown);
			this.TitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
			this.TitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseUp);
			// 
			// titleLabel
			// 
			this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.titleLabel.AutoSize = true;
			this.titleLabel.Font = new System.Drawing.Font("rainyhearts", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.titleLabel.Location = new System.Drawing.Point(63, 9);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(63, 18);
			this.titleLabel.TabIndex = 5;
			this.titleLabel.Text = "Breeze";
			this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// minimiseButton
			// 
			this.minimiseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.expandButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.expandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(37)))), ((int)(((byte)(65)))));
			this.expandButton.BackgroundImage = global::Breeze.Properties.Resources.expandIcon;
			this.expandButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.expandButton.ForeColor = System.Drawing.Color.White;
			this.expandButton.Location = new System.Drawing.Point(909, 0);
			this.expandButton.Name = "expandButton";
			this.expandButton.Size = new System.Drawing.Size(46, 35);
			this.expandButton.TabIndex = 3;
			this.expandButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ExpandButton_MouseDown);
			this.expandButton.MouseEnter += new System.EventHandler(this.ExpandButton_MouseEnter);
			this.expandButton.MouseLeave += new System.EventHandler(this.ExpandButton_MouseExit);
			// 
			// exitButton
			// 
			this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Breeze.Properties.Resources.icon;
			this.pictureBox1.Location = new System.Drawing.Point(4, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(52, 35);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(13)))), ((int)(((byte)(33)))));
			this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView1.Location = new System.Drawing.Point(0, 35);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(182, 589);
			this.treeView1.TabIndex = 2;
			// 
			// mainEditorBox
			// 
			this.mainEditorBox.AcceptsTab = true;
			this.mainEditorBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.mainEditorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
			this.mainEditorBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.mainEditorBox.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mainEditorBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
			this.mainEditorBox.Location = new System.Drawing.Point(2, 0);
			this.mainEditorBox.Name = "mainEditorBox";
			this.mainEditorBox.Size = new System.Drawing.Size(755, 574);
			this.mainEditorBox.TabIndex = 3;
			this.mainEditorBox.Text = "";
			this.mainEditorBox.WordWrap = false;
			this.mainEditorBox.VScroll += new System.EventHandler(this.MainEditor_VerticalChanged);
			this.mainEditorBox.TextChanged += new System.EventHandler(this.MainEditorBox_TextChanged);
			// 
			// editorBoxFocusLabel
			// 
			this.editorBoxFocusLabel.AutoSize = true;
			this.editorBoxFocusLabel.Location = new System.Drawing.Point(185, 587);
			this.editorBoxFocusLabel.Name = "editorBoxFocusLabel";
			this.editorBoxFocusLabel.Size = new System.Drawing.Size(0, 13);
			this.editorBoxFocusLabel.TabIndex = 4;
			// 
			// splitContainer
			// 
			this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer.IsSplitterFixed = true;
			this.splitContainer.Location = new System.Drawing.Point(190, 43);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.AutoScroll = true;
			this.splitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
			this.splitContainer.Panel1.Controls.Add(this.numberLineLable);
			this.splitContainer.Panel1.Controls.Add(this.lineNumberBox);
			this.splitContainer.Panel1.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.AutoScroll = true;
			this.splitContainer.Panel2.Controls.Add(this.mainEditorBox);
			this.splitContainer.Panel2.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.splitContainer.Size = new System.Drawing.Size(803, 574);
			this.splitContainer.SplitterDistance = 42;
			this.splitContainer.TabIndex = 5;
			// 
			// numberLineLable
			// 
			this.numberLineLable.AutoSize = true;
			this.numberLineLable.ForeColor = System.Drawing.Color.Gray;
			this.numberLineLable.Location = new System.Drawing.Point(13, 0);
			this.numberLineLable.Name = "numberLineLable";
			this.numberLineLable.Size = new System.Drawing.Size(0, 16);
			this.numberLineLable.TabIndex = 1;
			this.numberLineLable.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lineNumberBox
			// 
			this.lineNumberBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.lineNumberBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
			this.lineNumberBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lineNumberBox.ForeColor = System.Drawing.Color.Gray;
			this.lineNumberBox.Location = new System.Drawing.Point(0, 0);
			this.lineNumberBox.Name = "lineNumberBox";
			this.lineNumberBox.ReadOnly = true;
			this.lineNumberBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lineNumberBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.lineNumberBox.Size = new System.Drawing.Size(42, 574);
			this.lineNumberBox.TabIndex = 6;
			this.lineNumberBox.Text = "1\n2\n3\n4\n5\n6\n7\n8\n9\n10\n11\n12\n13\n14\n15\n16\n17\n18\n19\n20\n21\n22\n23\n24\n25\n26\n27\n28\n29\n30\n" +
    "31\n32\n33";
			this.lineNumberBox.WordWrap = false;
			// 
			// Breeze
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(51)))));
			this.ClientSize = new System.Drawing.Size(1000, 624);
			this.ControlBox = false;
			this.Controls.Add(this.splitContainer);
			this.Controls.Add(this.editorBoxFocusLabel);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.TitleBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Breeze";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.TitleBar.ResumeLayout(false);
			this.TitleBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel1.PerformLayout();
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

			}

		#endregion
		private System.Windows.Forms.Panel TitleBar;
		    private System.Windows.Forms.Panel expandButton;
		    private System.Windows.Forms.Panel exitButton;
		    private System.Windows.Forms.Panel minimiseButton;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.RichTextBox mainEditorBox;
		private System.Windows.Forms.Label editorBoxFocusLabel;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.Label numberLineLable;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.RichTextBox lineNumberBox;
	}
}

