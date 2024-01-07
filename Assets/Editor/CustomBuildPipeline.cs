using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Unity.SharpZipLib.Utils;

namespace FiFolker
{
    public class CustomBuildPipeline
    {

        private static readonly string[] Scenes = {
            "Assets/Scenes/TestScene.unity"
        };

        [MenuItem("File/Custom Build/Build for Windows")]
        public static void BuildGameForWindows(){
            var pathOfBuild = EditorUtility.SaveFolderPanel("Choose Location for your build", "", "New Windows Build");
            var dateAndTime = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            var folderName = "/Deliverist_Windows_"+dateAndTime;
            Directory.CreateDirectory(pathOfBuild + folderName);

            BuildPipeline.BuildPlayer(Scenes, pathOfBuild + folderName +  "/Deliverist.exe", BuildTarget.StandaloneWindows64, BuildOptions.None);

            
            ZipUtility.CompressFolderToZip(pathOfBuild + folderName + ".zip", null, pathOfBuild + folderName);
        }

        [MenuItem("File/Custom Build/Build for Linux")]
        public static void BuildGameForLinux(){
            var pathOfBuild = EditorUtility.SaveFolderPanel("Choose Location for your build", "", "New Linux Build");
            var dateAndTime = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
            var folderName = "/Deliverist_Linux_"+dateAndTime;
            Directory.CreateDirectory(pathOfBuild + folderName);

            BuildPipeline.BuildPlayer(Scenes, pathOfBuild + "/Deliverist.w86_64", BuildTarget.StandaloneLinux64, BuildOptions.None);

            
            ZipUtility.CompressFolderToZip(pathOfBuild + folderName + ".zip", null, pathOfBuild + folderName);
        }

    }
}
