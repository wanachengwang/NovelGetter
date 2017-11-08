using System;
using System.Reflection;

internal class Class18
{
	internal static Module eibbDcEcC;

	static Class18()
	{
		Class19.Q77LubhzKM3NS();
		Class18.eibbDcEcC = typeof(Class18).Assembly.ManifestModule;
	}

	public Class18()
	{
		Class19.Q77LubhzKM3NS();
	}

	internal static void wqELubhhaUDhS(int typemdt)
	{
		Type type = Class18.eibbDcEcC.ResolveType(33554432 + typemdt);
		FieldInfo[] fields = type.GetFields();
		for (int i = 0; i < (int)fields.Length; i++)
		{
			FieldInfo fieldInfo = fields[i];
			MethodInfo methodInfo = (MethodInfo)Class18.eibbDcEcC.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, methodInfo));
		}
	}

	internal delegate void Delegate4(object o);
}