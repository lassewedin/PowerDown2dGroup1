using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public static class PowerDownManager
{
	public static HashSet<Type> m_ActivePowerDowns = new HashSet<Type>();

	public static List<IPowerDown> m_PowerDowns = new List<IPowerDown>();
	
    static PowerDownManager()
    {
        Type interfaceType = typeof(IPowerDown);
		Assembly assembly = interfaceType.Assembly;
		var classTypes = assembly.GetTypes().Where(t => t.IsAbstract == false && interfaceType.IsAssignableFrom(t));

        foreach (var type in classTypes) {
			Instantiate(type);
		}
	}

	private static void Instantiate(Type type) {
		try {
			IPowerDown instance = (IPowerDown)Activator.CreateInstance(type);
			m_PowerDowns.Add(instance);
		} catch {
			Debug.LogError(string.Format("Failed to instantiate '{0}'", type.Name));
		}
	}

	public static bool IsPowerDownActive<T>() where T : IPowerDown {
		return m_ActivePowerDowns.Contains(typeof(T));
	}

}
