using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 6f;
    public float rotationSpeed = 2f;

    private Rigidbody2D rb;

    [SerializeField]
    private GameObject moneyPrefab;

    void Start()
    {
        float difficultySpeedMultiplier = ScoreScript.score / 100 + 1;
        if (difficultySpeedMultiplier >= 2)
        {
            difficultySpeedMultiplier = 2;
        }

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * difficultySpeedMultiplier, 0);
        rotationSpeed = Random.Range(rotationSpeed * difficultySpeedMultiplier, rotationSpeed *2);
        rb.angularVelocity = rotationSpeed;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            PlayerMovement playerScr = player.GetComponent<PlayerMovement>();
            playerScr.Die();
            GameManager.GameOver();
        }
        GameObject money = Instantiate(moneyPrefab);
        money.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
