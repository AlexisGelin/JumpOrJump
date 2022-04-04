using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBonus : MonoBehaviour
{
    private Vector2 spawnPosition;
    private static bool canSpawnBonus = true;

    void Start()
    {
        spawnPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        StartCoroutine(SpawnBon());
    }

    private void Bonus()
    {
        if (!GameManager.isGameStart || GameManager.isGameOver)
        {
            return;
        }
        int nbr = Random.Range(0, 3);
        if (nbr == 0)
        {
            Debug.Log("+5 cash");
        }
        if (nbr == 1)
        {
            Debug.Log("+1 Jump");
        }
        if (nbr == 2)
        {
            Debug.Log("Invincible");
        }
    }

    IEnumerator SpawnBon()
    {
        while (true && canSpawnBonus)
        {
            yield return new WaitForSeconds(5f);
            Bonus();
        }

    }
}
