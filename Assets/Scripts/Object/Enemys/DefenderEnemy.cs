using UnityEngine;
public class DefenderEnemy : Enemy
{
    public void OnTakelessDamage(float damage, float defense)
    {
        float defenseDamage = damage - defense;
        float resultDamage = defenseDamage < 0 ? 0 : defenseDamage;

        _curHp -= resultDamage;

        Debug.Log($"DefHP = {_curHp}");

        if (_curHp <= 0)
        {
            _curHp = 0;
            Destroy(gameObject);
        }
    }
}
