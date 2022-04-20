
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;


public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI maxScoreText;
    public TextMeshProUGUI scoreTextGameOver;
    public TextMeshProUGUI scoreTextMaxScore;

    public static int score = 0;
    public static int maxScore = 0;

    void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");
        scoreText.text = "" + score;
        maxScoreText.text = "" + maxScore;
    }

    private void Update()
    {
        scoreText.text = "" + score;
        maxScoreText.text = "" + maxScore;
        scoreTextGameOver.text = "" + score;
        scoreTextMaxScore.text = "Meilleur Score : " + maxScore;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("MaxScore",maxScore);

        if (score >= maxScore)
        {
            maxScore = score;
        }

        if (GameManager.isGameOver == true)
        {
            if (GameManager.isConnectedToGooglePlay)
            {
                Social.ReportScore(maxScore, "CgkIsLXcoY8KEAIQAg", (bool success) => {
                    if (!success) Debug.Log("Unable to post meilleur score");
                });
            }
        }
    }

    public static void addScore(int amount)
    {
        score += amount;
    }



}
