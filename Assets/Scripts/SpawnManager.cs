using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject planktonPrefab;
    private GameObject player;

    private float spawnRangeX;
    private float spawnRangeZ;
    private float cameraHeight;
    private float cameraWidth;

    public int waveNumber = 0;
    public int enemyCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        player = GameObject.Find("Jellyfish");
        Camera camera = Camera.main;
        cameraHeight = camera.orthographicSize;
        cameraWidth = cameraHeight * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Plankton>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveNumber);
            waveNumber++;
        }
        spawnRangeX = cameraWidth;
        spawnRangeZ = cameraHeight;
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xRange = Random.Range(-spawnRangeX + player.transform.position.x, spawnRangeX + player.transform.position.x);
        float zRange = Random.Range(-spawnRangeZ + player.transform.position.z, spawnRangeZ + player.transform.position.z);
        Vector3 randomSpawn = new Vector3(xRange, 0, zRange);
        return randomSpawn;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(planktonPrefab, GenerateSpawnPosition(), planktonPrefab.transform.rotation);
        }
    }
}
