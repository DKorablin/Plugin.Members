using System;
using System.Collections.Generic;
using System.Globalization;
using SAL.Flatbed;

namespace Plugin.Members.TypeWrapper
{
	internal class PluginParameterWrapper : IComparable
	{
		private readonly IPluginParameterInfo _parameter;

		private readonly PluginTypeWrapper _type;

		public EditorType EditorType { get => this._type.EditorType; }

		public String FriendlyTypeName { get => this._type.FriendlyName; }

		public Boolean IsValid { get => this._type.IsValid; }

		public ICollection<PluginTypeWrapper> Members { get => this._type.Members; }

		//public ICollection<PluginTypeWrapper> SubTypes { get => this._type.SubTypes; }

		public String TypeName { get => this._type.TypeName; }

		public String VariableName { get => this._parameter.Name; }

		public Boolean HasMembers { get => this._type.HasMembers; }

		public Boolean IsContainer { get => this._type.IsContainer; }

		public Boolean IsGeneric { get => this._type.IsGeneric; }

		public Boolean IsEnum { get => this._type.IsEnum; }

		public Boolean IsStruct { get => this._type.IsStruct; }

		public PluginParameterWrapper(IPluginParameterInfo parameter)
		{
			this._parameter = parameter ?? throw new ArgumentNullException(nameof(parameter));
			this._type = PluginTypeWrapper.GetTypeWrapper(parameter);

			foreach(IPluginMemberInfo member in parameter.Members)
				if(member is IPluginTypeInfo subType)
					this.Members.Add(PluginTypeWrapper.GetTypeWrapper(subType));
		}

		public Int32 CompareTo(Object obj)
		{
			PluginParameterWrapper serviceMemberInfo = (PluginParameterWrapper)obj;
			return this._parameter.Name.CompareTo(serviceMemberInfo._parameter.Name);
		}

		public String GetDefaultValue()
			=> this._type.GetDefaultValue();

		public Object GetObject(String value, VariableWrapper[] variables)
			=> this._type.GetObject(value, variables);

		public String[] GetSelectionList()
			=> this._type.GetSelectionList();

		public String GetStringRepresentation(Object obj)
			=> this._type.GetStringRepresentation(obj);

		public String ValidateAndCanonicalize(String value, out String errorMessage)
		{
			String text = this._type.ValidateAndCanonicalize(value, out Int32 num);
			errorMessage = null;

			if(text == null)
				errorMessage = String.Format(CultureInfo.CurrentUICulture, "'{0}' is not valid value for this type", value);
			return text;
		}
	}
}