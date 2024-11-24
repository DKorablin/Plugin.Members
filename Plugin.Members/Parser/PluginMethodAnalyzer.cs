using System.Collections.Generic;
using Plugin.Members.TypeWrapper;
using SAL.Flatbed;

namespace Plugin.Members.Parser
{
	internal class PluginMethodAnalyzer
	{
		private readonly IPluginDescription _plugin;
		private readonly IPluginTypeInfo _type;

		public PluginMethodAnalyzer(IPluginDescription plugin, IPluginTypeInfo type)
		{
			this._plugin = plugin;
			this._type = type;
		}

		public IEnumerable<PluginMethodWrapper> GetMethods()
		{
			foreach(IPluginMemberInfo member in this._type.Members)
				if(member.MemberType == System.Reflection.MemberTypes.Method)
				{
					IPluginMethodInfo method = (IPluginMethodInfo)member;
					PluginMethodWrapper result = new PluginMethodWrapper(this._plugin, method);
					foreach(IPluginParameterInfo parameter in method.GetParameters())
						result.InputParameters.Add(new PluginParameterWrapper(parameter));

					yield return result;
				}
		}
	}
}