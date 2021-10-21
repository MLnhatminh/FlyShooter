using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text gameScore;
    public GameObject gameOverPanel;

    public void UpdateGameScore(string txt)
    {
        if (gameScore)
        {
            gameScore.text = txt;
        }
    }

    public void ShowGameOverPanel(bool isGameOver)
    {
        gameOverPanel.SetActive(isGameOver);
    }
}
