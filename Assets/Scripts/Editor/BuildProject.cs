using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO.Compression;
 
class BuildProject : Editor{
    static string[] GetBuildScenes()
    {
        List<string> names = new List<string>();
        foreach(EditorBuildSettingsScene e in EditorBuildSettings.scenes)
        {
            if(e==null)
                continue;
			
            if(e.enabled){
                names.Add(e.path);
            }
        }
        return names.ToArray();
    }
	
    static List<string> GetArgs(string methodName) 
    {
        string executeMethod = "BuildProject." + methodName;
        List<string> args = new List<string> ();
        bool isArg = false;
        foreach(string arg in System.Environment.GetCommandLineArgs()) {
            if(isArg) {
                args.Add(arg);
            }else if(arg == executeMethod) {
                isArg = true;
            }
        }
        return args;
    }
    //shell脚本调用此方法进行打包pc
    static void BuildForPC()
    {
        List<string> args = GetArgs("BuildForPC");
        if(string.IsNullOrEmpty(BuildPipeline.BuildPlayer(GetBuildScenes(),args[0], BuildTarget.StandaloneWindows,BuildOptions.None).ToString())){
 
        }
 
    }
}