using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeederEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _weakness;

    //¾î´ðÆ¼
    private SpeederEnemy _enemy;

    //Åë¿ª ¿¬°á
    private void Start()
    {
        _enemy = GetComponent<SpeederEnemy>();

        if (_enemy == null)
            gameObject.SetActive(false);
    }
    
    //Å¸°Ù
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMoreDamage(damage, _weakness);
    }    
}
