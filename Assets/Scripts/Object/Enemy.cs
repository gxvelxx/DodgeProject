using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f; // 적 이동속도
    //[SerializeField] private Transform _playerTarget; // 플레이어 위치

    private void Update()
    {
        MoveToBack();
    }

    private void MoveToBack()
    {
        //if (_playerTarget == null)
        //    return;

        //플레이어한테 이동
        //Vector3 direction = (_playerTarget.position - transform.position).normalized;
        transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        //총알에 맞으면
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        //플레이어와 충돌시
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
