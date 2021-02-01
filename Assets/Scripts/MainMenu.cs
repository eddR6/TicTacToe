using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button changeBoard;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button submitButton;
    [SerializeField]
    private Text nameBoard;
    [SerializeField]
    private Text scoreBoard;
    [SerializeField]
    private InputField playerName;

    void Start()
    {
        playButton.onClick.AddListener(LoadGame);
        quitButton.onClick.AddListener(QuitGame);
        submitButton.onClick.AddListener(SubmitPlayerName);
        SaveSystem.CheckAndCreateSaveDir();
        SaveSystem.LoadGame();
        UpdateLeaderBoard();
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void LoadGame()
    {
        UIManager.ChangeUI("GameBoard");
    }

    private void UpdateLeaderBoard()
    {
        for(int i = 0; i < SaveSystem.HighScores.Length; i++)
        {
            nameBoard.text += SaveSystem.Scorers[i] + "\n ";
            scoreBoard.text += SaveSystem.HighScores[i] + "\n"; ;
        }
    }

    private void SubmitPlayerName()
    {
        ScoreManager.playerName = playerName.text;
        UIManager.ChangeUI("MainMenu");
    }
}
