using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject planktonPrefab;

    private float spawnRange = 10.0f;

    public int waveNumber = 1;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Plankton>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xRange = Random.Range(-spawnRange, spawnRange);
        float zRange = Random.Range(-spawnRange, spawnRange);
        Vector3 randomSpawn = new Vector3(xRange, 0, zRange);
        return randomSpawn;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(planktonPrefab, GenerateSpawnPosition(), planktonPrefab.transform.rotation);
        }
    }
}
