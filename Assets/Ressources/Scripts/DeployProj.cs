using System.Collections;
using UnityEngine;


public class DeployProj : MonoBehaviour
{
    [SerializeField]
    private bool right = false;
    public GameObject warningPrefab;
    public GameObject projectilePrefab;
    public float respawnTime = 0.2f;
    private Vector2 spawnPosition;
    private Vector2 pos;

    void Start()
    {
        spawnPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        StartCoroutine(projWave());
    }

    private void SpawnProjectile()
    {
        if (!GameManager.isGameStart || GameManager.isGameOver){
            return;
        }
        float distance = 1f;
        GameObject warn = Instantiate(warningPrefab);

        if (right)
        {
            pos = new Vector2(spawnPosition.x, Random.Range(1, (spawnPosition.y * 2) - 1));
            warn.transform.position = pos; // StartCoroutine pour delay l'apparition de la box
            StartCoroutine(TheProj(pos));
        }
        else
        {
            pos = new Vector2(spawnPosition.x, Random.Range(1, (spawnPosition.y * 2) - 1));
            warn.transform.position = pos; // StartCoroutine pour delay l'apparition de la box
            StartCoroutine(TheProj(pos));
        }
            
    }

    IEnumerator TheProj(Vector2 pos)
    {
        yield return new WaitForSeconds(1f);
        GameObject proj = Instantiate(projectilePrefab);
        proj.transform.position = pos;
    }

    IEnumerator projWave()
    {
        while(true)
        {
            float difficultySpawnProj = 1f -  ScoreScript.score / 100;
            if (difficultySpawnProj <= respawnTime + 0.2f)
            {
                difficultySpawnProj = respawnTime + 0.2f;
            }

            yield return new WaitForSeconds(Random.Range(respawnTime,respawnTime+ difficultySpawnProj));
            SpawnProjectile();
        }
    }
}
