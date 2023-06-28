using System;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundle
{
    [MenuItem("Assets/Create Asset Bundles")]
    private static void BuildAllAssetsBundles()
    {
        string assetBundleDirectoryPath = Application.dataPath + "/../AssetBundles";
        try
        {
            BuildPipeline.BuildAssetBundles(assetBundleDirectoryPath, BuildAssetBundleOptions.None, EditorUserBuildSettings.activeBuildTarget);
        }
        catch(Exception e)
        {
            Debug.LogWarning(e);
        }
    }
}
