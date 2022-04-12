using MyBox;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Separator("Box settings")]
    [SerializeField]
    private float speed = 6f;
    [SerializeField]
    private float rotationSpeed = 2f;

    private enum Box { None, Straight, Sinus, Jump };
    [Separator("Box movement")]

    [SerializeField]
    private Box boxMovement = Box.None;

    [ConditionalField(nameof(boxMovement), false, Box.Sinus)] public float frequency = 3f;

    [ConditionalField(nameof(boxMovement), false, Box.Jump)] public float force = 3f;

    [Separator("Others")]

    [SerializeField]
    private GameObject moneyPrefab;

    private Rigidbody2D rb;
    private float difficultySpeedMultiplier;

    void Start()
    {

        difficultySpeedMultiplier = ScoreScript.score / 100 + 1;
        if (difficultySpeedMultiplier >= 2)
        {
            difficultySpeedMultiplier = 2;
        }
        rb = GetComponent<Rigidbody2D>();

        if (boxMovement == Box.Straight)
        {
            rb.velocity = new Vector2(speed * difficultySpeedMultiplier, 0);
        }
        if (boxMovement == Box.Sinus)
        {
            frequency = Random.Range(frequency, frequency * 2);
            rotationSpeed = Random.Range(rotationSpeed * difficultySpeedMultiplier, rotationSpeed * 2);
        }
        if (boxMovement == Box.Jump)
        {
            rb.velocity = new Vector2(speed * difficultySpeedMultiplier, 0);
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
        rotationSpeed = Random.Range(-rotationSpeed * difficultySpeedMultiplier, rotationSpeed * difficultySpeedMultiplier);
        rb.angularVelocity = rotationSpeed;
    }

    private void Update()
    {
        if (boxMovement == Box.Sinus)
        {
            rb.velocity = new Vector2(speed * difficultySpeedMultiplier, Mathf.Sin(Time.time * frequency) * 3);
        }
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
