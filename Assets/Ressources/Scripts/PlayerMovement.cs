using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private int nbrJump = 0;
    private int maxJump = 2;
    private float JumpForce = 6f;

    public Animator _animator;

    public AudioClip[] jumpSoundArray;
    private AudioClip jumpSound;

    public AudioSource audioSource;

    public AudioClip hitSong;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            nbrJump = 0;
            _animator.SetBool("isGrounded", true);
            _animator.SetBool("Jump", false);
            _animator.SetBool("DoubleJump", false);
        }
        else
        {
            _animator.SetBool("isGrounded", false);
        }
    }

    public void Jump()
    {
        if (GameManager.isGameOver)
        {
            return;
        }
        if (nbrJump < maxJump)
        {
            int choice = Random.Range(0, 3);
            jumpSound = jumpSoundArray[choice];
            audioSource.clip = jumpSound;
            audioSource.Play();
            GameManager.isGameStart = true;
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _animator.SetBool("Jump", true);
            nbrJump += 1;
            ScoreScript.addScore(nbrJump);
            if (nbrJump == 2)
            {
                _animator.SetBool("DoubleJump", true);
            }
        }
    }

    public void Die()
    {
        audioSource.clip = hitSong;
        audioSource.Play();
        _animator.SetBool("Jump", false);
        _animator.SetBool("DoubleJump", false);
        _animator.SetBool("Live", false);

        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector2(0.6f,0.12f);
        if (ScoreScript.maxScore < ScoreScript.score)
        {
            ScoreScript.maxScore = ScoreScript.score;
        }
    }
}
