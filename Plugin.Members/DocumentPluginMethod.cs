using System;
using System.Windows.Forms;
using SAL.Flatbed;
using SAL.Windows;
using Microsoft.VisualStudio.VirtualTreeGrid;
using Plugin.Members.Properties;
using Plugin.Members.TypeWrapper;
using Plugin.Members.UI;

namespace Plugin.Members
{
	public partial class DocumentPluginMethod : UserControl, IPluginSettings<DocumentPluginMethodSettings>
	{
		private DocumentPluginMethodSettings _settings;
		private PluginMethodWrapper _method;

		internal PluginWindows Plugin { get => (PluginWindows)this.Window.Plugin; }

		private IWindow Window { get => (IWindow)base.Parent; }

		Object IPluginSettings.Settings { get => this.Settings; }

		public DocumentPluginMethodSettings Settings
		{
			get => this._settings?? (this._settings = new DocumentPluginMethodSettings());
		}

		public DocumentPluginMethod()
		{
			InitializeComponent();
			VirtualTreeColumnHeader[] headers = new VirtualTreeColumnHeader[]
			{
				new VirtualTreeColumnHeader(Resources.colMethodName),
				new VirtualTreeColumnHeader(Resources.colMethodValue),
				new VirtualTreeColumnHeader(Resources.colMethodType)
			};
			gridInput.SetColumnHeaders(headers, true);
			gridInput.KeyDown += new KeyEventHandler(this.gridInput_KeyDown);
			VirtualTreeColumnHeader[] headers2 = new VirtualTreeColumnHeader[]
			{
				new VirtualTreeColumnHeader(Resources.colMethodName),
				new VirtualTreeColumnHeader(Resources.colMethodValue),
				new VirtualTreeColumnHeader(Resources.colMethodType)
			};
			gridOutput.SetColumnHeaders(headers2, true);
			gridOutput.KeyDown += new KeyEventHandler(this.gridOutput_KeyDown);
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			this.InitMethod();
		}

		private void InitMethod()
		{
			IPluginDescription plugin = this.Plugin.HostWindows.Plugins[this.Settings.PluginId];
			this._method = new PluginMethodWrapper(plugin, plugin.Type.GetMember<IPluginMethodInfo>(this.Settings.MethodName));

			this.Window.Caption = String.Join(" - ", new String[] { plugin.Name, this._method.Method.Name, });

			VariableWrapper[] variables = this._method.GetVariables();
			this.PopulateTree(variables, gridInput, false);
		}

		private void gridInput_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.C | Keys.Control:
				ColumnItemEnumerator columnItemEnumerator = gridInput.CreateSelectedItemEnumerator();
				Int32 row = columnItemEnumerator.RowInTree + 1;
				Int32 columnInTree = columnItemEnumerator.ColumnInTree;
				VirtualTreeItemInfo itemInfo = gridInput.Tree.GetItemInfo(row, columnInTree, false);
				String text = itemInfo.Branch.GetText(itemInfo.Row, itemInfo.Column);
				if(!String.IsNullOrEmpty(text))
					Clipboard.SetText(text);
				break;
			}
		}

		private void gridOutput_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.C | Keys.Control:
				ColumnItemEnumerator columnItemEnumerator = gridOutput.CreateSelectedItemEnumerator();
				Int32 row = columnItemEnumerator.RowInTree + 1;
				Int32 columnInTree = columnItemEnumerator.ColumnInTree;
				VirtualTreeItemInfo itemInfo = gridOutput.Tree.GetItemInfo(row, columnInTree, false);
				String text = itemInfo.Branch.GetText(itemInfo.Row, itemInfo.Column);
				if(!String.IsNullOrEmpty(text))
					Clipboard.SetText(text);
				break;
			}
		}

		private void PanelMethodInvoker_OnValueUpdated(Object sender, EventArgs e)
			=> this.gridOutput.MultiColumnTree = null;

		private void tsbnInvoke_Click(Object sender, EventArgs e)
		{
			PluginMethodWrapper method = this._method;
			VariableWrapper[] variables = this.GetVariables();
			this.InvokeMethod(method, variables);
		}

		private void InvokeMethod(PluginMethodWrapper method, VariableWrapper[] variables)
		{
			Object[] args = Array.ConvertAll(variables, p => p.GetObject());
			Object result = method.Method.Invoke(args);
		}

		private void PopulateTree(VariableWrapper[] variables, VirtualTreeControl parameterTreeView, Boolean readOnly)
		{
			parameterTreeView.MultiColumnTree = new MultiColumnTree(3);
			ITree tree = (ITree)parameterTreeView.MultiColumnTree;
			tree.Root = new ParameterTreeAdapter(tree, parameterTreeView, variables, readOnly, null);
			((ParameterTreeAdapter)((ITree)gridInput.MultiColumnTree).Root).OnValueUpdated += new EventHandler<EventArgs>(PanelMethodInvoker_OnValueUpdated);
		}

		private VariableWrapper[] GetVariables()
			=> ((ParameterTreeAdapter)((ITree)gridInput.MultiColumnTree).Root).GetVariables();
	}
}