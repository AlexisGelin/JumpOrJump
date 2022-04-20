using System.Collections;
using UnityEngine;


public class DeployProj : MonoBehaviour
{
    [SerializeField]
    private bool right = false;
    public GameObject[] warningPrefab;
    public GameObject[] projectilePrefab;
    public float respawnTime = 1f;
    private Vector2 spawnPosition;
    private Vector2 pos;

    private float difficultySpawnProj;

    private int choice;

    void Start()
    {
        spawnPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        StartCoroutine(projWave());
    }

    private void SpawnProjectile()
    {
        if (!GameManager.isGameStart || GameManager.isGameOver)
        {
            return;
        }

        choice = SelectProj();

        GameObject warn = Instantiate(warningPrefab[choice]);

        if (right)
        {
            pos = new Vector2(spawnPosition.x, Random.Range(1, (spawnPosition.y * 2) - 1));
            warn.transform.position = pos; // StartCoroutine pour delay l'apparition de la box
            StartCoroutine(TheProj(pos, choice));
        }
        else
        {
            pos = new Vector2(spawnPosition.x, Random.Range(1, (spawnPosition.y * 2) - 1));
            warn.transform.position = pos; // StartCoroutine pour delay l'apparition de la box
            StartCoroutine(TheProj(pos, choice));
        }
        Destroy(warn, 1);

    }

    private int SelectProj()
    {
        int choice;
        if (ScoreScript.score <= 20)
        {
            choice = Random.Range(0, 1);
        }
        else if (ScoreScript.score <= 50)
        {
            choice = Random.Range(0, 2);
        }
        else
        {
            choice = Random.Range(0, 3);
        }
        return choice;
    }

    IEnumerator TheProj(Vector2 pos, int choice)
    {
        yield return new WaitForSeconds(1);
        GameObject proj = Instantiate(projectilePrefab[choice]);
        proj.transform.position = pos;
    }

    IEnumerator projWave()
    {
        while (true)
        {
            float timingSpawn = SelectTimingRespawn();
            yield return new WaitForSeconds(timingSpawn);
            SpawnProjectile();
        }
    }
    private float SelectTimingRespawn()
    {
        difficultySpawnProj = respawnTime + 3f - ScoreScript.score / 100;

        if (difficultySpawnProj <= respawnTime + 0.5f)
        {
            difficultySpawnProj = respawnTime + 0.5f;
        }

        float timingSpawn = Random.Range(respawnTime, difficultySpawnProj);
        return timingSpawn;
    }
}
