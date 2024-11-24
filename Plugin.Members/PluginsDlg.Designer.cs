namespace Plugin.Members
{
	partial class PluginsDlg
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.ColumnHeader colName;
			System.Windows.Forms.GroupBox gbInformation;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PluginsDlg));
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.txtSource = new System.Windows.Forms.TextBox();
			this.txtId = new System.Windows.Forms.TextBox();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.splitMain = new System.Windows.Forms.SplitContainer();
			this.splitInformation = new System.Windows.Forms.SplitContainer();
			this.lvPlugins = new System.Windows.Forms.ListView();
			this.ilPlugin = new System.Windows.Forms.ImageList(this.components);
			this.lvMembers = new System.Windows.Forms.ListView();
			this.colMemberName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ilMember = new System.Windows.Forms.ImageList(this.components);
			this.tt = new System.Windows.Forms.ToolTip(this.components);
			this.tCloseInfo = new System.Windows.Forms.Timer(this.components);
			colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			gbInformation = new System.Windows.Forms.GroupBox();
			gbInformation.SuspendLayout();
			this.splitMain.Panel1.SuspendLayout();
			this.splitMain.Panel2.SuspendLayout();
			this.splitMain.SuspendLayout();
			this.splitInformation.Panel1.SuspendLayout();
			this.splitInformation.Panel2.SuspendLayout();
			this.splitInformation.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbInformation
			// 
			gbInformation.Controls.Add(this.txtDescription);
			gbInformation.Controls.Add(this.txtSource);
			gbInformation.Controls.Add(this.txtId);
			gbInformation.Controls.Add(this.txtAuthor);
			gbInformation.Controls.Add(this.txtVersion);
			gbInformation.Controls.Add(this.txtName);
			resources.ApplyResources(gbInformation, "gbInformation");
			gbInformation.Name = "gbInformation";
			gbInformation.TabStop = false;
			// 
			// txtDescription
			// 
			resources.ApplyResources(this.txtDescription, "txtDescription");
			this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.tt.SetToolTip(this.txtDescription, resources.GetString("txtDescription.ToolTip"));
			this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtSource
			// 
			resources.ApplyResources(this.txtSource, "txtSource");
			this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtSource.Name = "txtSource";
			this.txtSource.ReadOnly = true;
			this.tt.SetToolTip(this.txtSource, resources.GetString("txtSource.ToolTip"));
			this.txtSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtId
			// 
			resources.ApplyResources(this.txtId, "txtId");
			this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtId.Name = "txtId";
			this.txtId.ReadOnly = true;
			this.txtId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtAuthor
			// 
			resources.ApplyResources(this.txtAuthor, "txtAuthor");
			this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.ReadOnly = true;
			this.tt.SetToolTip(this.txtAuthor, resources.GetString("txtAuthor.ToolTip"));
			this.txtAuthor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtVersion
			// 
			resources.ApplyResources(this.txtVersion, "txtVersion");
			this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.ReadOnly = true;
			this.tt.SetToolTip(this.txtVersion, resources.GetString("txtVersion.ToolTip"));
			this.txtVersion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// txtName
			// 
			resources.ApplyResources(this.txtName, "txtName");
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.tt.SetToolTip(this.txtName, resources.GetString("txtName.ToolTip"));
			this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
			// 
			// splitMain
			// 
			resources.ApplyResources(this.splitMain, "splitMain");
			this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitMain.Name = "splitMain";
			// 
			// splitMain.Panel1
			// 
			this.splitMain.Panel1.Controls.Add(this.splitInformation);
			// 
			// splitMain.Panel2
			// 
			this.splitMain.Panel2.Controls.Add(this.lvMembers);
			// 
			// splitInformation
			// 
			resources.ApplyResources(this.splitInformation, "splitInformation");
			this.splitInformation.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitInformation.Name = "splitInformation";
			// 
			// splitInformation.Panel1
			// 
			this.splitInformation.Panel1.Controls.Add(this.lvPlugins);
			// 
			// splitInformation.Panel2
			// 
			this.splitInformation.Panel2.Controls.Add(gbInformation);
			// 
			// lvPlugins
			// 
			this.lvPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            colName});
			resources.ApplyResources(this.lvPlugins, "lvPlugins");
			this.lvPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lvPlugins.HideSelection = false;
			this.lvPlugins.MultiSelect = false;
			this.lvPlugins.Name = "lvPlugins";
			this.lvPlugins.SmallImageList = this.ilPlugin;
			this.lvPlugins.UseCompatibleStateImageBehavior = false;
			this.lvPlugins.View = System.Windows.Forms.View.Details;
			this.lvPlugins.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvPlugins_ItemSelectionChanged);
			this.lvPlugins.SizeChanged += new System.EventHandler(this.lvPlugins_SizeChanged);
			// 
			// ilPlugin
			// 
			this.ilPlugin.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilPlugin.ImageStream")));
			this.ilPlugin.TransparentColor = System.Drawing.Color.Fuchsia;
			this.ilPlugin.Images.SetKeyName(0, "imageOptions.bmp");
			// 
			// lvMembers
			// 
			this.lvMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMemberName});
			resources.ApplyResources(this.lvMembers, "lvMembers");
			this.lvMembers.FullRowSelect = true;
			this.lvMembers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvMembers.Name = "lvMembers";
			this.lvMembers.SmallImageList = this.ilMember;
			this.lvMembers.UseCompatibleStateImageBehavior = false;
			this.lvMembers.View = System.Windows.Forms.View.Details;
			this.lvMembers.DoubleClick += new System.EventHandler(this.lvMembers_DoubleClick);
			// 
			// colMemberName
			// 
			resources.ApplyResources(this.colMemberName, "colMemberName");
			// 
			// ilMember
			// 
			this.ilMember.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMember.ImageStream")));
			this.ilMember.TransparentColor = System.Drawing.Color.Fuchsia;
			this.ilMember.Images.SetKeyName(0, "Empty.bmp");
			this.ilMember.Images.SetKeyName(1, "Method.Public.bmp");
			this.ilMember.Images.SetKeyName(2, "Property.Public.bmp");
			this.ilMember.Images.SetKeyName(3, "Event.Public.bmp");
			this.ilMember.Images.SetKeyName(4, "Field.Public.bmp");
			// 
			// tCloseInfo
			// 
			this.tCloseInfo.Tick += new System.EventHandler(this.tCloseInfo_Tick);
			// 
			// PluginsDlg
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PluginsDlg";
			this.ShowIcon = false;
			this.Load += new System.EventHandler(this.PluginsDlg_Load);
			gbInformation.ResumeLayout(false);
			gbInformation.PerformLayout();
			this.splitMain.Panel1.ResumeLayout(false);
			this.splitMain.Panel2.ResumeLayout(false);
			this.splitMain.ResumeLayout(false);
			this.splitInformation.Panel1.ResumeLayout(false);
			this.splitInformation.Panel2.ResumeLayout(false);
			this.splitInformation.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitMain;
		private System.Windows.Forms.ListView lvPlugins;
		private System.Windows.Forms.ListView lvMembers;
		private System.Windows.Forms.ImageList ilPlugin;
		private System.Windows.Forms.SplitContainer splitInformation;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.ToolTip tt;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.TextBox txtSource;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.ColumnHeader colMemberName;
		private System.Windows.Forms.ImageList ilMember;
		private System.Windows.Forms.Timer tCloseInfo;
	}
}