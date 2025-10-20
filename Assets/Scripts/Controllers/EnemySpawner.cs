using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;    
    [SerializeField] private float _spawnRate = 0.2f; // 생성속도
    [SerializeField] private int _maxEnemies = 50; // 최대 적수
    [SerializeField] private float _spawnRadius = 80f; // 생성반경

    private int _currentEnemyCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }
    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            // 다음생성까지 대기
            yield return new WaitForSeconds(_spawnRate);

            // 최대치면 스킵
            if (_currentEnemyCount >= _maxEnemies)
                continue;

            SpawnEnemy();       
        }
    }

    private void SpawnEnemy()
    {
        //생성 랜덤위치
        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-_spawnRadius, _spawnRadius), 0, 0);

        //적프리팹
        GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        _currentEnemyCount++;

        //적파괴시 카운트감소
        StartCoroutine(TrackEnemyLifeTime(newEnemy));
    }

    private IEnumerator TrackEnemyLifeTime(GameObject enemy)
    {
        yield return new WaitUntil(() => enemy == null);
        _currentEnemyCount--;
    }
}
