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
        List<Component> compList = new List<Component>();
        foreach (GameObject obj in FindObjectsOfType(typeof(GameObject)))
        {
            Component[] comps = obj.GetComponents<Component>();
            foreach(Component comp in comps)
            {
                int id = comp.GetInstanceID();
                compList.Add(comp);
                string guid;
                long lid;
                bool find=AssetDatabase.TryGetGUIDAndLocalFileIdentifier(comp, out guid, out lid);
                Debug.Log(comp.name +" "+comp.GetType()+ " " +" guid: "+guid+">> lid : "+lid+"]]find: "+find);
            }
        }
    
        string[] str = GetAssets();
        //Debug.Log(str.Length + " " + compList.Count);
        string assetKey=string.Empty;
        string assetValue = string.Empty;
        int count = 0;
        foreach (string s in str)
        {
            if (s.Contains("Assets/"))
            {
                GUILayout.BeginHorizontal();
                //GUILayout.Label();
                assetKey = "Element " + count.ToString();
                count++;
                assetValue = s.Substring(s.LastIndexOf('/') + 1, s.Length - s.LastIndexOf('/') - 1);
                EditorGUILayout.TextField(assetKey, assetValue);
              //  foreach (Component com in compList)
              //  {
                 //   int id = com.GetInstanceID();
                 //   string guid;
                 //   long lid;
                 //   AssetDatabase.TryGetGUIDAndLocalFileIdentifier(id, out guid, out lid);
                 //   string guidd = AssetDatabase.AssetPathToGUID(s);
                 //   Debug.Log("||" + guid);
                //    Debug.Log("|>>>|" + guidd);
               //     if (guid == guidd)
                 //   {
                //        Debug.Log(s + " --- " + com.name);
                //    }
               // }

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

