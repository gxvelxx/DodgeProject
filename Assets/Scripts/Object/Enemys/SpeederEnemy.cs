using UnityEngine;
public class SpeederEnemy : Enemy
{
    public void OnTakeMoreDamage(float damage, float weakness)
    {
        float resultDamage = damage + weakness;

        _curHp -= resultDamage;

        Debug.Log($"SpdHP = {_curHp}");

        if (_curHp <= 0)
        {
            _curHp = 0;
            Destroy(gameObject);
        }
    }
}
