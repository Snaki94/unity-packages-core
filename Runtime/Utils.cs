using System;
using UnityEngine;

namespace PolySnake.Core
{
    public static class Utils
    {
        public static void InvokeMethodByReflection(string assemblyName, string className, string methodName,
            object[] parameters)
        {
            System.Reflection.Assembly customLoggerAssembly = System.Reflection.Assembly.Load(assemblyName);
            Type customLoggerType = customLoggerAssembly.GetType(className);
            object customLoggerObj = System.Activator.CreateInstance(customLoggerType);
            System.Reflection.MethodInfo method = customLoggerType.GetMethod(methodName);
            if (method != null)
            {
                method.Invoke(customLoggerObj, parameters);
            }
            else
            {
                Debug.LogError($"Method {methodName} doesnt exist in the specified context");
            }
        }
    }
}