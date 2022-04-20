using System.Collections;
using UnityEngine;


public class DeployProj : MonoBehaviour
{
    [SerializeField]
    private bool right = false;
    public GameObject[] warningPrefab;
    public GameObject[] projectilePrefab;
    public float respawnTime = 20f;
    private Vector2 spawnPosition;
    private Vector2 pos;

    private float timingSpawn;
    

    void Start()
    {
        spawnPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        StartCoroutine(projWave());

        float difficultySpawnProj = 1f - ScoreScript.score / 100; // A revoir
        if (difficultySpawnProj <= respawnTime + 0.2f)
        {
            difficultySpawnProj = respawnTime + 0.2f;
        }
        timingSpawn = Random.Range(respawnTime, respawnTime + difficultySpawnProj);
    }

    private void SpawnProjectile()
    {
        int choice = SelectProj();

        if (!GameManager.isGameStart || GameManager.isGameOver)
        {
            return;
        }

        GameObject warn = Instantiate(warningPrefab[choice]);

        if (right)
        {
            pos = new Vector2(spawnPosition.x, Random.Range(1, (spawnPosition.y * 2) - 1));
            warn.transform.position = pos; // StartCoroutine pour delay l'apparition de la box
            StartCoroutine(TheProj(pos,choice));
        }
        else
        {
            pos = new Vector2(spawnPosition.x, Random.Range(1, (spawnPosition.y * 2) - 1));
            warn.transform.position = pos; // StartCoroutine pour delay l'apparition de la box
            StartCoroutine(TheProj(pos,choice));
        }
        Destroy(warn, timingSpawn);

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

    IEnumerator TheProj(Vector2 pos,int choice)
    {
        yield return new WaitForSeconds(1f);
        GameObject proj = Instantiate(projectilePrefab[choice]);
        proj.transform.position = pos;
    }

    IEnumerator projWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timingSpawn);
            SpawnProjectile();
        }
    }



}
