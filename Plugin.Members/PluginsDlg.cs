using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using SAL.Flatbed;
using SAL.Windows;

namespace Plugin.Members
{
	internal partial class PluginsDlg : Form
	{
		private readonly PluginWindows _plugin;
		private static readonly Dictionary<MemberTypes, Int32> MemberTypeMapping = new Dictionary<MemberTypes, Int32>()
		{
			{ MemberTypes.Method, 1 },
			{ MemberTypes.Property, 2 },
			{ MemberTypes.Event, 3 },
			{ MemberTypes.Field, 4 },
		};

		/// <summary>Selected plugin in the list</summary>
		protected IPluginDescription SelectedPlugin { get => lvPlugins.SelectedItems.Count > 0 ? (IPluginDescription)lvPlugins.SelectedItems[0].Tag : null; }

		public PluginsDlg(PluginWindows plugin)
		{
			this._plugin = plugin ?? throw new ArgumentNullException(nameof(plugin));

			this.InitializeComponent();
			splitInformation.Panel2Collapsed = true;
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			base.Hide();
			base.OnClosing(e);
		}

		private void PluginsDlg_Load(Object sender, EventArgs e)
		{
			List<ListViewItem> itemsToAdd = new List<ListViewItem>((Int32)this._plugin.HostWindows.Plugins.Count);
			foreach(IPluginDescription plugin in this._plugin.HostWindows.Plugins)
			{
				ListViewItem item = new ListViewItem(plugin.Name)
				{
					Tag = plugin,
					ImageIndex = 0,
					StateImageIndex = 0
				};

				if(plugin.Instance is IKernelInfo app)
				{
					if(app.ApplicationIcon is Icon ico)
					{
						ilPlugin.Images.Add(ico);
						item.ImageIndex = ilPlugin.Images.Count - 1;
					}

					/*if(plugin.Equals(this.Host.Plugins.KernelPlugin))
						item.ForeColor = Color.Red;*/
				}
				itemsToAdd.Add(item);
			}
			lvPlugins.Items.AddRange(itemsToAdd.ToArray());
			this.lvPlugins_SizeChanged(sender, e);
		}

		private void lvPlugins_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
		{
			try
			{
				lvMembers.Items.Clear();
				if(e.IsSelected)
				{
					tCloseInfo.Stop();
					IPluginDescription plugin = (IPluginDescription)e.Item.Tag;
					splitInformation.Panel2Collapsed = false;
					txtName.Text = plugin.Name;
					txtId.Text = plugin.ID;
					txtAuthor.Text = plugin.Company;
					txtVersion.Text = plugin.Version.ToString();
					txtSource.Text = plugin.Source;
					txtDescription.Text = plugin.Description;

					tt.SetToolTip(txtSource, plugin.Source);

					List<ListViewItem> itemsToAdd = new List<ListViewItem>();
					foreach(IPluginMemberInfo member in plugin.Type.Members)
						itemsToAdd.Add(this.CreateMemberItem(member));

					lvMembers.Items.AddRange(itemsToAdd.ToArray());
					lvMembers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
				} else
					tCloseInfo.Start();
			} catch(Exception exc)
			{
				this._plugin.Trace.TraceData(TraceEventType.Error, 10, exc);
			}
		}

		private void lvMembers_DoubleClick(Object sender, EventArgs e)
		{
			ListViewItem item = lvMembers.SelectedItems.Count == 0 ? null : lvMembers.SelectedItems[0];
			if(item != null)
			{
				IPluginDescription plugin = (IPluginDescription)lvPlugins.SelectedItems[0].Tag;
				IPluginMemberInfo member = (IPluginMemberInfo)item.Tag;
				if(member.MemberType == MemberTypes.Method)
				{
					IWindow window = this._plugin.HostWindows.Windows.CreateWindow(
						this._plugin,
						typeof(DocumentPluginMethod).ToString(),
						true,
						DockState.Document,
						new DocumentPluginMethodSettings() { PluginId = plugin.ID, MethodName = member.Name });
				}
			}
		}

		private void tCloseInfo_Tick(Object sender, EventArgs e)
		{
			tCloseInfo.Stop();

			splitInformation.Panel2Collapsed = true;
		}

		private void lvPlugins_SizeChanged(Object sender, EventArgs e)
			=> lvPlugins.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

		private void txtItem_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.A | Keys.Control:
				e.Handled = true;
				((TextBox)sender).SelectAll();
				break;
			}
		}

		private ListViewItem CreateMemberItem(IPluginMemberInfo member)
		{
			ListViewItem result = new ListViewItem();
			String[] subItems = Array.ConvertAll<String, String>(new String[lvMembers.Columns.Count], a => String.Empty);
			result.SubItems.AddRange(subItems);

			Int32 imageIndex = PluginsDlg.MemberTypeMapping.TryGetValue(member.MemberType, out imageIndex) ? imageIndex : 0;
			result.ImageIndex = result.StateImageIndex = imageIndex;

			result.Group = this.GetMemberGroup(member);
			result.Tag = member;

			String memberName = member.Name;

			if(member.MemberType == MemberTypes.Method)
			{
				IPluginMethodInfo method = (IPluginMethodInfo)member;
				List<String> parameters = new List<String>();
				foreach(IPluginParameterInfo parameter in method.GetParameters())
					parameters.Add(parameter.TypeName + " " + parameter.Name);

				memberName += "(" + String.Join(", ", parameters.ToArray()) + ")";
			}

			result.SubItems[colMemberName.Index].Text = memberName;

			return result;
		}

		private ListViewGroup GetMemberGroup(IPluginMemberInfo member)
		{
			MemberTypes type = member.MemberType;

			ListViewGroup result = lvMembers.Groups[type.ToString()]
				?? lvMembers.Groups.Add(type.ToString(), type.ToString());

			return result;
		}
	}
}