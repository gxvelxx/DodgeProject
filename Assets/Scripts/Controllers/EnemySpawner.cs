using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;    
    [SerializeField] private float _spawnRate = 0.2f; // �����ӵ�
    [SerializeField] private int _maxEnemies = 50; // �ִ� ����
    [SerializeField] private float _spawnRadius = 80f; // �����ݰ�

    private int _currentEnemyCount = 0;

    //�ڷ�ƾ �ڵ��� ������ ����
    private Coroutine _spawnEnemyCoroutine;
    private void Start()
    {
        StartGameAction();
    }
    private void StartGameAction() // ������ ����
    {
        StartSpawnEnemy();
    }
    private void StartSpawnEnemy() // ������ �ڷ�ƾ����
    {
        //�ڷ�ƾ Ȯ��
        if (_spawnEnemyCoroutine != null)
            _spawnEnemyCoroutine = null; // �ʱ�ȭ
        
        //�����
        _spawnEnemyCoroutine = StartCoroutine(SpawnEnemyProcess());
    }
    private IEnumerator SpawnEnemyProcess() //������ ����
    {
        while (true)
        {
            // ������������ ���
            yield return new WaitForSeconds(_spawnRate);

            // �ִ�ġ�� ��ŵ
            if (_currentEnemyCount >= _maxEnemies)
                continue;

            SpawnEnemy();       
        }
    }

    private void SpawnEnemy()
    {
        //���� ������ġ
        Vector3 spawnPos = transform.position + new Vector3(
            Random.Range(-_spawnRadius, _spawnRadius), 0, 0);

        //��������
        GameObject newEnemy = Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
        _currentEnemyCount++;

        //���ı��� ī��Ʈ����
        StartCoroutine(TrackEnemyLifeTime(newEnemy));
    }

    private IEnumerator TrackEnemyLifeTime(GameObject enemy)
    {
        yield return new WaitUntil(() => enemy == null);
        _currentEnemyCount--;
    }
}
