using System.Collections;
using UnityEngine;

public class WaveEnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform _transformSpawners;
    [SerializeField] private Enemy _enemy;

    private Transform[] _spawnerPoints;
    private Coroutine _spawnWaveEnemyes;

    private void Start()
    {
        _spawnerPoints = new Transform[_transformSpawners.childCount];
        _spawnWaveEnemyes = StartCoroutine(CreateWave());
    }

    private void RestartCoroutine()
    {
        StopCoroutine(_spawnWaveEnemyes);
        _spawnWaveEnemyes = StartCoroutine(CreateWave());
    }

    private void CreateEnemyes()
    {
        for (int i = 0; i < _transformSpawners.childCount; i++)
        {
            _spawnerPoints[i] = transform.GetChild(i);
            Instantiate(_enemy, _spawnerPoints[i].transform.position, Quaternion.identity);
        }
    }

    private IEnumerator CreateWave()
    {
        var waitForTenSSeconds = new WaitForSeconds(10);

        for (int i = 0; i < _transformSpawners.childCount; i++)
        {
            CreateEnemyes();
            yield return waitForTenSSeconds;
        }

        RestartCoroutine();
    }
}