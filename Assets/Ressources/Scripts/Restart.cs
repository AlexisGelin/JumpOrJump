using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public GameObject btnPub;
    public GameObject player;
    private Animator playerAnim;

    public void RestartGame()
    {
        SceneManager.LoadScene("Main");
        GameManager.isGameOver = false;
        GameManager.isGameStart = false;
        ScoreScript.score = 0;
    }

    public void PubReplay()
    {
        BoxCollider2D boxCollider2D = player.GetComponent<BoxCollider2D>();
        UIManager uimanager = GetComponent<UIManager>();
        uimanager.ClosePause();
        PlayerTimeGrounded._time = 10;
        player.transform.position += new Vector3(0, 1, 0); 
        boxCollider2D.size = new Vector2(0.6f, 0.9f);
        GameManager.isGameOver = false;
        GameManager.isGameStart = true;
        btnPub.SetActive(false);
        playerAnim = player.GetComponent<Animator>();
        playerAnim.SetBool("Jump", false);
        playerAnim.SetBool("DoubleJump", false);
        playerAnim.SetBool("Live", true);
    }
}
