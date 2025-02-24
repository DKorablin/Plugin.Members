using System.Reflection;
using System.Runtime.InteropServices;

[assembly: Guid("dbd0389f-bd3c-45ef-81f7-bcee9d99d7c4")]
[assembly: System.CLSCompliant(true)]

#if NETCOREAPP
[assembly: AssemblyMetadata("ProjectUrl", "https://dkorablin.ru/project/Default.aspx?File=98")]
#else

[assembly: AssemblyDescription("Show loaded plugins public methods and properties")]
[assembly: AssemblyCopyright("Copyright © Danila Korablin 2016-2024")]
#endif

/*if $(ConfigurationName) == Release (
..\..\..\..\ILMerge.exe "/out:$(ProjectDir)..\bin\$(TargetFileName)" "$(TargetDir)$(TargetFileName)" "$(ProjectDir)Microsoft.VisualStudio.VirtualTreeGrid.dll" "/lib:..\..\..\SAL\bin"
)*/