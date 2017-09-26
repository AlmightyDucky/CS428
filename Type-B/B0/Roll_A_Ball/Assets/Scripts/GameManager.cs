using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Members
    public static bool timeRanOut = false;

    private int p1Score;
    private int p2Score;

    public static GameManager instance;

    public Text p1ScoreText;
    public Text p2ScoreText;
    public Text winText;
    #endregion

    #region GameManager Methods

    void Awake()
    {
        instance = this;
        timeRanOut = false;
    }

    // Use this for initialization
    void Start ()
    {
        InitializeScoreText();
        winText.text = "";
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timeRanOut)
        {
            if (p1Score > p2Score)
            {
                winText.text = "Player 1 Wins!";
            }
            else if (p2Score > p1Score)
            {
                winText.text = "Player 2 Wins!";
            }
            else
            {
                winText.text = "Draw!";
            }
        }
    }

    public void InitializeScoreText()
    {
        p1ScoreText.text = "Player 1 Score: 0";
        p2ScoreText.text = "Player 2 Score: 0";

    }

    public void SetScoreText(int pid, int points)
    {
        if (pid == 1)
        {
            p1Score += points;
            p1ScoreText.text = "Player 1 Score: " + p1Score.ToString();
        }

        if (pid == 2)
        {
            p2Score += points;
            p2ScoreText.text = "Player 2 Score: " + p2Score.ToString();
        }
    }

    #endregion
}
