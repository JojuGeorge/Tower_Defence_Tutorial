using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public static int enemiesAlive = 0;

    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;


    private int _waveNumber = 0;

    private float _countDown = 2f;
    public float CountDown { get { return _countDown; } set { _countDown = value; } }

    // Singleton
    private static WaveSpawner _instance;
    public static WaveSpawner Instance { get { return _instance; } }

    
    private void Awake()
    {
        // Needs this inorder for proper working of singleton
        if(Instance == null)
        {
            _instance = this;
        }
    }


    private void Update()
    {

        if(enemiesAlive > 0) { return; }        // start next wave after all enemies are dead

        CountDown -= Time.deltaTime;

        if(CountDown <= 0)
        {
            StartCoroutine(SpawnWave());
            CountDown = _timeBetweenWaves;
            return;
        }
    }

    IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;
        Wave wave = waves[_waveNumber];

        Debug.Log("wave count = " + _waveNumber);
        for (int i = 0; i < wave.enemyCount; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1 / wave.spawnRate);
        }

        _waveNumber++;
        if (_waveNumber == waves.Length)
        {
            Debug.Log("Next level");
            this.enabled = false;
        }

    }

    private void  SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _enemySpawnPoint.position, Quaternion.identity);
        enemiesAlive++;
    }
}
