namespace Plugin.Members
{
	partial class DocumentPluginMethod
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbnInvoke = new System.Windows.Forms.ToolStripButton();
			this.tscMain = new System.Windows.Forms.ToolStripContainer();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.gridInput = new Plugin.Members.UI.VirtualTreeControl2();
			this.gridOutput = new Plugin.Members.UI.VirtualTreeControl2();
			this.tsMain.SuspendLayout();
			this.tscMain.ContentPanel.SuspendLayout();
			this.tscMain.TopToolStripPanel.SuspendLayout();
			this.tscMain.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsMain
			// 
			this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbnInvoke});
			this.tsMain.Location = new System.Drawing.Point(3, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(66, 25);
			this.tsMain.TabIndex = 0;
			// 
			// tsbnInvoke
			// 
			this.tsbnInvoke.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbnInvoke.Image = global::Plugin.Members.Properties.Resources.iconDebug;
			this.tsbnInvoke.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbnInvoke.Name = "tsbnInvoke";
			this.tsbnInvoke.Size = new System.Drawing.Size(23, 22);
			this.tsbnInvoke.Text = "&Invoke method";
			this.tsbnInvoke.Click += new System.EventHandler(this.tsbnInvoke_Click);
			// 
			// tscMain
			// 
			// 
			// tscMain.ContentPanel
			// 
			this.tscMain.ContentPanel.Controls.Add(this.splitMain);
			this.tscMain.ContentPanel.Size = new System.Drawing.Size(150, 125);
			this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tscMain.Location = new System.Drawing.Point(0, 0);
			this.tscMain.Name = "tscMain";
			this.tscMain.Size = new System.Drawing.Size(150, 150);
			this.tscMain.TabIndex = 1;
			// 
			// tscMain.TopToolStripPanel
			// 
			this.tscMain.TopToolStripPanel.Controls.Add(this.tsMain);
			// 
			// splitMain
			// 
			this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitMain.Location = new System.Drawing.Point(0, 0);
			this.splitMain.Name = "splitMain";
			this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.gridInput);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.gridOutput);
			this.splitMain.Size = new System.Drawing.Size(150, 125);
			this.splitMain.SplitterDistance = 62;
			this.splitMain.TabIndex = 0;
			// 
			// gridInput
			// 
			this.gridInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridInput.HasGridLines = true;
			this.gridInput.HasHorizontalGridLines = true;
			this.gridInput.HasVerticalGridLines = true;
			this.gridInput.LabelEditSupport = Microsoft.VisualStudio.VirtualTreeGrid.VirtualTreeLabelEditActivationStyles.ImmediateSelection;
			this.gridInput.Location = new System.Drawing.Point(0, 0);
			this.gridInput.Name = "gridInput";
			this.gridInput.Size = new System.Drawing.Size(150, 62);
			this.gridInput.TabIndex = 0;
			// 
			// gridOutput
			// 
			this.gridOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridOutput.HasGridLines = true;
			this.gridOutput.HasHorizontalGridLines = true;
			this.gridOutput.HasVerticalGridLines = true;
			this.gridOutput.LabelEditSupport = Microsoft.VisualStudio.VirtualTreeGrid.VirtualTreeLabelEditActivationStyles.ImmediateSelection;
			this.gridOutput.Location = new System.Drawing.Point(0, 0);
			this.gridOutput.Name = "gridOutput";
			this.gridOutput.Size = new System.Drawing.Size(150, 59);
			this.gridOutput.TabIndex = 0;
			// 
			// DocumentPluginMethod
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tscMain);
			this.Name = "DocumentPluginMethod";
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.tscMain.ContentPanel.ResumeLayout(false);
			this.tscMain.TopToolStripPanel.ResumeLayout(false);
			this.tscMain.TopToolStripPanel.PerformLayout();
			this.tscMain.ResumeLayout(false);
			this.tscMain.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripContainer tscMain;
		private System.Windows.Forms.SplitContainer splitMain;
		private Plugin.Members.UI.VirtualTreeControl2 gridInput;
		private Plugin.Members.UI.VirtualTreeControl2 gridOutput;
		private System.Windows.Forms.ToolStripButton tsbnInvoke;
	}
}