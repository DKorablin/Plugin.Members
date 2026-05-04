using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Microsoft.VisualStudio.VirtualTreeGrid;

namespace Plugin.Members.UI
{
	/// <summary>TypeEditorHost wrapper that catches Win32Exception from OpenDropDown and substitutes a ContextMenuStrip.</summary>
	internal sealed class SafeTypeEditorHost : TypeEditorHost
	{
		private readonly String[] _choices;
		private readonly Action<String> _commitCallback;

		internal SafeTypeEditorHost(PropertyDescriptor descriptor, Object instance, String[] choices, Action<String> commitCallback)
			: base(UITypeEditorEditStyle.DropDown, descriptor, instance, TypeEditorHostEditControlStyle.Editable)
		{
			this._choices = choices;
			this._commitCallback = commitCallback;
		}

		protected override void WndProc(ref Message m)
		{
			try
			{
				base.WndProc(ref m);
			}
			catch(Win32Exception)
			{
				// OpenDropDown failed (e.g. "Class already exists" on net8.0-windows).
				// Fall back to a ContextMenuStrip so the user can still pick a value.
				this.ShowChoicesMenu();
			}
		}

		private void ShowChoicesMenu()
		{
			if(this._choices == null || this._choices.Length == 0)
				return;

			ContextMenuStrip menu = new ContextMenuStrip();
			menu.Closed += (s, e) => ((ContextMenuStrip)s).Dispose();

			foreach(String choice in this._choices)
			{
				String captured = choice;
				ToolStripMenuItem item = new ToolStripMenuItem(captured);
				item.Click += (s, e) => this._commitCallback(captured);
				menu.Items.Add(item);
			}

			menu.Show(this, new Point(0, this.Height));
		}
	}
}
