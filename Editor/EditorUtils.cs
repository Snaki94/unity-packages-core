using UnityEditor;

namespace PolySnake.Core.Editor
{
    public static class EditorUtils
    {
        public static void AddDefineSymbolOnBuildTargetGroup(BuildTargetGroup buildTargetGroup, string moduleKey)
        {
            var currentData = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);

            if (currentData.Contains(moduleKey)) return;

            if (string.IsNullOrEmpty(currentData))
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, moduleKey);
            }
            else
            {
                if (!currentData[^1].Equals(';'))
                {
                    currentData = $"{currentData};";
                }

                currentData = $"{currentData}{moduleKey}";
                PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, currentData);
            }
        }

        public static void RemoveDefineSymbolOnBuildTargetGroup(BuildTargetGroup buildTargetGroup, string moduleKey)
        {
            var currentData = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);

            if (!currentData.Contains(moduleKey)) return;

            currentData = currentData.Replace($"{moduleKey};", "");
            currentData = currentData.Replace($";{moduleKey}", "");
            currentData = currentData.Replace(moduleKey, "");
            PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup, currentData);
        }

        public static void InitializeSymbol(string symbolDefine)
        {
            AddDefineSymbolOnBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup,
                symbolDefine);
        }

        public static void DeInitializeSymbol(string symbolDefine)
        {
            RemoveDefineSymbolOnBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup,
                symbolDefine);
        }

    }
}