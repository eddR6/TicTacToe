using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class AssetsInfo : EditorWindow
{
    [MenuItem("Window/Assetsinfo")]
    public static void ShowWindow()
    {
        GetWindow<AssetsInfo>();
    }

    private void OnGUI()
    {
        List<GameObject> gameObjs = new List<GameObject>();
        foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
        {
            gameObjs.Add(obj);
        }
        string[] str = GetAssets();
        foreach (string s in str)
        {
            if (s.Contains("Assets/"))
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label(s.Substring(s.LastIndexOf('/')+1,s.Length- s.LastIndexOf('/')-1));
                foreach(GameObject obj in gameObjs)
                {
                    Component[] comps = obj.GetComponents<Component>();
                    foreach(Component com in comps)
                    {
                       // com.get
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
    }
    

    private string[] GetAssets()
    {
        string[] str = AssetDatabase.GetAllAssetPaths();
        return str;
      
    }
}
// Object[] objs= AssetDatabase.LoadAllAssetsAtPath(s);
// if (objs == null || objs.Length == 0)
// {
//     Debug.Log("nothing at path " + s);
//    continue;
// }
//foreach (Object obj in objs)
// {
//     if (obj == null)
//         continue;
//    Debug.Log("path " + s + " Type: " + obj.GetType().ToString());
// }