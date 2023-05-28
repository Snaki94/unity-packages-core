using System;
using UnityEditor;

namespace PolySnake.Core
{
    public static class Utils
    {
        public static void AddDefineSymbolOnBuildTargetGroup(BuildTargetGroup buildTargetGroup, String moduleKey)
        {
            var currentData = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);
            
            if (currentData.Contains(moduleKey)) return;
            
            if( string.IsNullOrEmpty( currentData ) )
            {
                PlayerSettings.SetScriptingDefineSymbolsForGroup( buildTargetGroup , moduleKey );
            }
            else
            {
                if( !currentData[^1].Equals( ';' ) )
                {
                    currentData += ';';
                }
                currentData += moduleKey;
                PlayerSettings.SetScriptingDefineSymbolsForGroup( buildTargetGroup , currentData );
            }
        }

        public static void RemoveDefineSymbolOnBuildTargetGroup(BuildTargetGroup buildTargetGroup, String moduleKey)
        {
            var currentData = PlayerSettings.GetScriptingDefineSymbolsForGroup( buildTargetGroup );
            
            if (!currentData.Contains(moduleKey)) return;
            
            currentData = currentData.Replace( moduleKey + ";" , "" );
            currentData = currentData.Replace( ";" + moduleKey , "" );
            currentData = currentData.Replace( moduleKey , "" );
            PlayerSettings.SetScriptingDefineSymbolsForGroup( buildTargetGroup , currentData );
        }
    }
}
