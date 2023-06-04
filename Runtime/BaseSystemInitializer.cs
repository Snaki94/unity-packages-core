using UnityEditor;

namespace PolySnake.Core
{
    public static class BaseSystemInitializer
    {
        public static void InitializeSymbol(string symbolDefine)
        {
            Utils.AddDefineSymbolOnBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup, 
                symbolDefine);
        }

        //TODO: Check how to remove symbol define after removing form the project
        public static void DeInitializeSymbol(string symbolDefine)
        {
            Utils.RemoveDefineSymbolOnBuildTargetGroup(EditorUserBuildSettings.selectedBuildTargetGroup, 
                symbolDefine);
        }


    }
}