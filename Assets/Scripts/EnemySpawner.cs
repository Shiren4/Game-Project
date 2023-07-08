using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float initialSpawnDelay = 3f;
    [SerializeField] private float waveInterval = 10f;
    [SerializeField] private float spawnDelayMultiplier = 0.9f;
    [SerializeField] private float spawnSpeedMultiplier = 1f;
    [SerializeField] private int initialSpawnCount = 5;
    [SerializeField] private int spawnCountIncrement = 2;
    [SerializeField] private Text waveText;

    private int currentWave = 1;
    private int enemiesToSpawn;
    private int enemiesSpawned;

    private void Start()
    {
        StartCoroutine(SpawnWaveDelayed(initialSpawnDelay));
    }

    private IEnumerator SpawnWaveDelayed(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        waveText.text = "Wave: " + currentWave;

        enemiesToSpawn = initialSpawnCount + (spawnCountIncrement * (currentWave - 1));
        enemiesSpawned = 0;

        float spawnInterval = waveInterval / (enemiesToSpawn * spawnSpeedMultiplier);

        while (enemiesSpawned < enemiesToSpawn)
        {
            SpawnRandomEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }

        currentWave++;
        waveInterval *= spawnDelayMultiplier;
        StartCoroutine(SpawnWaveDelayed(waveInterval));
    }

    private void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-5f, 5f);
        float randomY = Random.Range(-6f, 6f);
        int enemyType = Random.Range(0, enemyPrefabs.Length);

        GameObject enemyPrefab = enemyPrefabs[enemyType];

        Instantiate(enemyPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
        enemiesSpawned++;
    }
}