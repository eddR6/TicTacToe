using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Themes : MonoSingletonGeneric<Themes>
{
    [SerializeField]
    private List<Theme> themes = new List<Theme>();
    private Theme currentTheme;
    [SerializeField]
    private Image nameUI;
    [SerializeField]
    private Image mainUI;
    [SerializeField]
    private Image gameUI;

    public Theme CurrentTheme { get => currentTheme; set => currentTheme = value; }
    public List<Theme> ThemesList { get => themes; set => themes = value; }

    public void SetTheme(string name)
    {
        foreach(Theme th in ThemesList)
        {
            if (th.name == name)
            {
                currentTheme = th;
            }
        }
        if (currentTheme != null)
        {
            nameUI.sprite = currentTheme.theme[0];
            mainUI.sprite = currentTheme.theme[1];
            gameUI.sprite = currentTheme.theme[2];
        }
    }
}
