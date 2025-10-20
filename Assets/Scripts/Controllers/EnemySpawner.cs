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

    //코루틴 핸들을 저장할 변수
    private Coroutine _spawnEnemyCoroutine;
    private void Start()
    {
        StartGameAction();
    }
    private void StartGameAction() // 게임의 시작
    {
        StartSpawnEnemy();
    }
    private void StartSpawnEnemy() // 적생성 코루틴시작
    {
        //코루틴 확인
        if (_spawnEnemyCoroutine != null)
            _spawnEnemyCoroutine = null; // 초기화
        
        //재시작
        _spawnEnemyCoroutine = StartCoroutine(SpawnEnemyProcess());
    }
    private IEnumerator SpawnEnemyProcess() //적생성 관리
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
