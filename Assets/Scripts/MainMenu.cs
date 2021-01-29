using System;
using System.Collections;
using System.Collections.Generic;
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
    private Text leaderBoard;
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
        leaderBoard.text = "-Leader Board-\n";
        for(int i = 0; i < SaveSystem.HighScores.Length; i++)
        {
            leaderBoard.text += SaveSystem.Scorers[i] + " : " + SaveSystem.HighScores[i] + "\n";
        }
    }

    private void SubmitPlayerName()
    {
        ScoreManager.playerName = playerName.text;
        UIManager.ChangeUI("MainMenu");
    }
}
