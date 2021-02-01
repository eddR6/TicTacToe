using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static Dictionary<string, GameObject> uicollection;
    private static GameObject currentUI;
    [SerializeField]
    private GameObject playerName;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject gameBoard;

    void Awake()
    {
        uicollection = new Dictionary<string, GameObject>();
        uicollection.Add("PlayerName", playerName);
        uicollection.Add("MainMenu",mainMenu);
        uicollection.Add("GameBoard", gameBoard);
        Debug.Log(uicollection["PlayerName"].name);
    }

    public static void SetCurrentUI(string ui)
    {
        currentUI = uicollection[ui].gameObject;
        currentUI.SetActive(true);
    }

    public static void ChangeUI(string ui)
    {
        currentUI.SetActive(false);
        GameObject temp = uicollection[ui];
        temp.SetActive(true);
        currentUI = temp;
    }
}
