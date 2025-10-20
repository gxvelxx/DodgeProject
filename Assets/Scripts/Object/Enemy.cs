using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 50f; // �� �̵��ӵ�
    //[SerializeField] private Transform _playerTarget; // �÷��̾� ��ġ

    private void Update()
    {
        MoveToBack();
    }

    private void MoveToBack()
    {
        //if (_playerTarget == null)
        //    return;

        //�÷��̾����� �̵�
        //Vector3 direction = (_playerTarget.position - transform.position).normalized;
        transform.Translate(Vector3.back * _moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        //�Ѿ˿� ������
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        //�÷��̾�� �浹��
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
