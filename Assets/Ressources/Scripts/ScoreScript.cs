
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score = 0;
    public static int maxScore = 0;

    void Start()
    {
        scoreText.text = "" + score;
    }
    private void Update()
    {
        scoreText.text = "" + score;
    }

    public static void addScore(int amount)
    {
        score += amount;
    }



}
