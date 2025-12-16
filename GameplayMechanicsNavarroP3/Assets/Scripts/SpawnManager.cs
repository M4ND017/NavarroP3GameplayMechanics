using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int waveNumber = 1;

    private bool waveInProgress = false;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    void Update()
    {
        // Count enemies in the scene
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Only spawn a new wave if all enemies are gone AND no wave is in progress
        if (enemyCount == 0 && !waveInProgress)
        {
            waveInProgress = true;
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
            waveInProgress = false;
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        if (GameObject.FindGameObjectWithTag("Powerup") == null)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
