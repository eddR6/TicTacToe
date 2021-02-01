using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardLogic : MonoBehaviour
{
    [SerializeField]
    private Text score;
    [SerializeField]
    private GameObject[] blocks;
    private string[] str;
    private CurrentPlayer currentPlayer;
    [SerializeField]
    private readonly int gridSize;
   

    private void Start()
    {
        currentPlayer=CurrentPlayer.Player;
        str = new string[blocks.Length];
        UIManager.SetCurrentUI("PlayerName");
       
    }

    public void UpdateScore()
    {
        score.text = "High Score: " + ScoreManager.GetScore();
    }

    public void UpdateBoard(int id)
    {
        string blockText = blocks[id].GetComponentInChildren<Text>().text;

        if (blockText != "")
        {
            return;
        }
        if (currentPlayer == CurrentPlayer.Player)
        {
            blocks[id].GetComponentInChildren<Text>().text = "x";
            if (!CheckForWinCondition())
            {
                currentPlayer = CurrentPlayer.CPU;
                CPUTurn();
            } 
        }  
    }

    private void CPUTurn()
    {
        List<int> emptyPlaces = new List<int>();
        for(int i = 0; i < gridSize * gridSize; i++)
        {
            if(blocks[i].GetComponentInChildren<Text>().text == "")
            {
                emptyPlaces.Add(i);
            }
        }
        int index = Random.Range(0, emptyPlaces.Count);
        blocks[emptyPlaces[index]].GetComponentInChildren<Text>().text = "o";
        if (!CheckForWinCondition())
        {
            currentPlayer = CurrentPlayer.Player;
        }
    }
 
    private bool CheckForWinCondition()
    {
        int k = 0;
        int n = gridSize;
        int emptyCount = 0;
        char[,] board = new char[n, n];
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if (blocks[k].GetComponentInChildren<Text>().text == "")
                {
                    board[i, j] = '-';
                    emptyCount++;
                }
                else
                {
                    board[i, j] = blocks[k].GetComponentInChildren<Text>().text[0];
                }
                k++;
            }
        }
        //check win condition
        //row
        for (int i = 0; i < n; i++)
        {
            bool inARow = true;
            char value = board[i, 0];

            if (value == '-')
            {
                inARow = false;
            }
            else
            {
                for (int j = 1; j < n; j++)
                {
                    if (board[i, j] != value)
                    {
                        inARow = false;
                        break;
                    }
                }
            }
            if (inARow)
            {
                DisplayWin(currentPlayer);
                return true;
            }
        }

        //col
        for (int j = 0; j < n; j++)
        {
            bool inACol = true;
            char value = board[0, j];

            if (value == '-')
            {
                inACol = false;

            }
            else
            {
                for (int i = 1; i < n; i++)
                {
                    if (board[i, j] != value)
                    {
                        inACol = false;
                        break;
                    }
                }
            }
            if (inACol)
            {
                DisplayWin(currentPlayer);
                return true;
            }
        }

        //d1
        bool inADiag1 = true;
        char value1 = board[0, 0];

        if (value1 == '-')
        {
            inADiag1 = false;
        }
        else
        {
            for (int i = 1; i < n; i++)
            {
                if (board[i, i] != value1)
                {
                    inADiag1 = false;
                    break;
                }
            }
        }

        if (inADiag1)
        {
            DisplayWin(currentPlayer);
            return true;
        }

        //d2
        bool inADiag2 = true;
        char value2 = board[0, n - 1];

        if (value2 == '-')
        {
            inADiag2 = false;
        }
        else
        {
            for (int i = 1; i < n; i++)
            {
                if (board[i, n - 1 - i] != value2)
                {
                    inADiag2 = false;
                    break;
                }
            }
        }
        if (inADiag2)
        {
            DisplayWin(currentPlayer);
            return true;
        }

        //tie
        if (emptyCount == 0)
        {
            DisplayTie();
            return true;
        }
        return false;
    }

    private void DisplayTie()
    {
        Toast.Instance.Show("Its a Tie!", 4f, Toast.ToastColor.Blue);
        ResetBoard();
    }

    private void DisplayWin(CurrentPlayer player)
    {
        if (player == CurrentPlayer.Player)
        {
            Toast.Instance.Show("Player Wins!", 4f, Toast.ToastColor.Green);
            ScoreManager.UpdateScore(10);
        }
        else
        {
            Toast.Instance.Show("CPU wins!", 4f, Toast.ToastColor.Red);
            ScoreManager.UpdateScore(0);
            currentPlayer = CurrentPlayer.Player;
        }
        ResetBoard();
    }

    void ResetBoard()
    {
        StartCoroutine(SceneReset());
    }

    IEnumerator SceneReset()
    {
        yield return new WaitForSeconds(2f);
        for(int i = 0; i < blocks.Length; i++)
        {
            blocks[i].GetComponentInChildren<Text>().text = "";
        }
        UpdateScore();
    }
}
