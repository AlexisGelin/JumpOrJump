using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        GameManager.isGameOver = false;
        GameManager.isGameStart = false;
        if (ScoreScript.maxScore < ScoreScript.score)
        {
            ScoreScript.maxScore = ScoreScript.score;
        }
        ScoreScript.score = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
