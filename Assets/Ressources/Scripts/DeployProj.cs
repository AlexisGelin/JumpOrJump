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
        GameObject proj = Instantiate(projectilePrefab);
        if (right)
        {
            pos = new Vector2(spawnPosition.x + distance, Random.Range(0, spawnPosition.y * 2));
            proj.transform.position = pos;
            warn.transform.position = pos - new Vector2(distance, 0);
        }
        else
        {
            pos = new Vector2(spawnPosition.x - distance, Random.Range(0, spawnPosition.y * 2));
            proj.transform.position = pos;
            warn.transform.position = pos + new Vector2(distance, 0);  
        }
            
    }

    IEnumerator projWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(respawnTime,respawnTime+1f));
            SpawnProjectile();
        }
    }
}
