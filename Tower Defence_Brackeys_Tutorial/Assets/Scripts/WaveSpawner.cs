using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Transform _enemyPrefab;
    [SerializeField] private Transform _enemySpawnPoint;
    [SerializeField] private float _timeBetweenWaves = 5f;
    [SerializeField] private float _delayBetweenEnemySpawn = .1f;         // Delay of each enemies in a spawn group


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
        CountDown -= Time.deltaTime;

        if(CountDown <= 0)
        {
            SpawnWave();
            CountDown = _timeBetweenWaves;
        }
    }

    private void SpawnWave()
    {
        _waveNumber++;
        PlayerStats.rounds++;
       StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < _waveNumber; i++)
        {
            Instantiate(_enemyPrefab, _enemySpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(_delayBetweenEnemySpawn);
        }
    }
}
