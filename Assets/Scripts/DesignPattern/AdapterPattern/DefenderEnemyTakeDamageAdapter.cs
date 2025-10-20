using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _defense;

    private DefenderEnemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<DefenderEnemy>();

        if (_enemy == null)
            gameObject.SetActive(false);
    }

    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakelessDamage(damage, _defense);
    }
}
