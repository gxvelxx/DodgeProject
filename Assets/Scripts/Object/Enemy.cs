using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _moveSpeed = 50f; // 적 이동속도
    [SerializeField] private float _maxHp;

    protected float _curHp;

    private void Start()
    {
        InitEnemy();
    }
    private void Update()
    {
        MoveToBack();
    }

    private void InitEnemy()
    {
        _curHp = _maxHp;
    }

    private void MoveToBack()
    {        
        transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        //플레이어와 충돌시
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player == null)
                return;

            player.OnTakeDamage(_damage);

            Destroy(gameObject);
            return;
        }
        ////총알에 맞으면
        //if (other.CompareTag("Bullet"))
        //{
        //    Destroy(gameObject);
        //    return;
        //}
    }

}
