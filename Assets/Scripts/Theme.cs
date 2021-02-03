using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Theme",menuName = "Scriptable Objects/Theme")]
public class Theme : ScriptableObject
{
    public string name;
    public List<Sprite> theme=new List<Sprite>();

}
