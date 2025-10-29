using System;
using System.Collections.Generic;
using System.Diagnostics;
using SAL.Flatbed;
using SAL.Windows;

namespace Plugin.Members
{
	public class PluginWindows : IPlugin
	{
		private TraceSource _trace;
		private PluginsDlg _plugins;
		private Dictionary<String, DockState> _documentTypes;

		internal TraceSource Trace => this._trace ?? (this._trace = PluginWindows.CreateTraceSource<PluginWindows>());

		internal IHostWindows HostWindows { get; }

		private IMenuItem ConfigMenu { get; set; }

		private Dictionary<String, DockState> DocumentTypes
		{
			get
			{
				if(this._documentTypes == null)
					this._documentTypes = new Dictionary<String, DockState>()
					{
						{ typeof(DocumentPluginMethod).ToString(), DockState.Document },
					};
				return this._documentTypes;
			}
		}

		public PluginWindows(IHostWindows hostWindows)
			=> this.HostWindows = hostWindows ?? throw new ArgumentNullException(nameof(hostWindows));

		public IWindow GetPluginControl(String typeName, Object args)
			=> this.CreateWindow(typeName, false, args);

		Boolean IPlugin.OnConnection(ConnectMode mode)
		{
			IMenuItem menuView = this.HostWindows.MainMenu.FindMenuItem("View");
			if(menuView == null)
				this.Trace.TraceEvent(TraceEventType.Error, 10, "Menu item 'View' not found");
			else
			{
				this.ConfigMenu = menuView.Create("&Members");
				this.ConfigMenu.Name = "View.Members";
				this.ConfigMenu.Click += new EventHandler(this.ConfigMenu_Click);
				menuView.Items.Insert(0, this.ConfigMenu);
				return true;
			}

			return false;
		}

		Boolean IPlugin.OnDisconnection(DisconnectMode mode)
		{
			this._plugins?.Dispose();

			if(this.ConfigMenu != null)
				this.HostWindows.MainMenu.Items.Remove(this.ConfigMenu);
			return true;
		}

		private IWindow CreateWindow(String typeName, Boolean searchForOpened, Object args = null)
			=> this.DocumentTypes.TryGetValue(typeName, out DockState state)
				? this.HostWindows.Windows.CreateWindow(this, typeName, searchForOpened, state, args)
				: null;

		private static TraceSource CreateTraceSource<T>(String name = null) where T : IPlugin
		{
			TraceSource result = new TraceSource(typeof(T).Assembly.GetName().Name + name);
			result.Switch.Level = SourceLevels.All;
			result.Listeners.Remove("Default");
			result.Listeners.AddRange(System.Diagnostics.Trace.Listeners);
			return result;
		}

		private void ConfigMenu_Click(Object sender, EventArgs e)
		{
			if(this._plugins == null)
				this._plugins = new PluginsDlg(this);
			this._plugins.Show();
		}
	}
}