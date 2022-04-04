using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        GameManager.isGameOver = false;
        GameManager.isGameStart = false;
        ScoreScript.score = 0;
    }

    public void PubReplay()
    {
        SceneManager.LoadScene("Main");
        GameManager.isGameOver = false;
        GameManager.isGameStart = true;
    }
}
