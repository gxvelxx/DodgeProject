using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _weakness;

    //���Ƽ
    private SpeederEnemy _enemy;

    //�뿪 ����
    private void Start()
    {
        _enemy = GetComponent<SpeederEnemy>();

        if (_enemy == null)
            gameObject.SetActive(false);
    }
    
    //Ÿ��
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMoreDamage(damage, _weakness);
    }    
}
