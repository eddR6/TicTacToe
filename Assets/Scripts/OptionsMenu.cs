using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    public GameObject mainmenu;
    public GameObject board;

    public void OnMainMenuButton()
    {

        mainmenu.SetActive(true);
        board.SetActive(false);
    }


}
