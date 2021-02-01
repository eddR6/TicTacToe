using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DictionaryInspector))]
public class DictionaryEditor :Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (((DictionaryInspector)target).modifyValues)
        {
            if(GUILayout.Button("Save Changes"))
            {
                ((DictionaryInspector)target).DeserializeDictionary();
            }
        }
    }
}
