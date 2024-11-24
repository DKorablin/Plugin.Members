using System;
using System.Collections.Generic;
using Plugin.Members.Extensions;
using SAL.Flatbed;

namespace Plugin.Members.TypeWrapper
{
	internal class PluginMethodWrapper
	{
		private readonly IPluginDescription _plugin;

		internal IList<PluginParameterWrapper> InputParameters { get; private set; }

		public IPluginMethodInfo Method { get; }

		private IList<PluginParameterWrapper> OtherParameters { get; set; }

		internal Boolean Valid
			=> this.InputParameters.Find(new Predicate<PluginParameterWrapper>(this.IsServiceMemberInValid)) == null
				&& this.OtherParameters.Find(new Predicate<PluginParameterWrapper>(this.IsServiceMemberInValid)) == null;

		internal PluginMethodWrapper(IPluginDescription plugin, IPluginMethodInfo method)
		{
			this._plugin = plugin ?? throw new ArgumentNullException(nameof(plugin));
			this.Method = method ?? throw new ArgumentNullException(nameof(method));

			this.InputParameters = new List<PluginParameterWrapper>();
			this.OtherParameters = new List<PluginParameterWrapper>();

			this.AnalyzeParameters();
		}

		private void AnalyzeParameters()
		{
			foreach(IPluginParameterInfo parameter in this.Method.GetParameters())
				this.InputParameters.Add(new PluginParameterWrapper(parameter));
		}

		public VariableWrapper[] GetVariables()
		{
			VariableWrapper[] array = new VariableWrapper[this.InputParameters.Count];
			Int32 num = 0;
			foreach(PluginParameterWrapper current in this.InputParameters)
			{
				array[num] = new VariableWrapper(current);
				array[num].SetServiceMethodInfo(this);
				num++;
			}
			return array;
		}

		private Boolean IsServiceMemberInValid(PluginParameterWrapper member)
			=> !member.IsValid;
	}
}