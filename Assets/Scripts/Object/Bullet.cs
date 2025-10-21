using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 160f; // �Ѿ� �ӵ�
    [SerializeField] private float _bulletTime = 2f; // �Ѿ� �����ð�
    [SerializeField] private float _damage;

    private void Start()
    {
        Destroy(gameObject, _bulletTime);
    }

    void Update()
    {
        Move();
    }
   
    private void Move()
    {
        //������ ���ư��� (Z����)
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
    }

    //�Ѿ� �浹ó��
    private void OnTriggerEnter(Collider other)
    {
        //���� �浹�ϸ� ����
        if (other.CompareTag("Enemy"))
        {
            ITakeDamageAdapter adapter = other.GetComponent<ITakeDamageAdapter>();

            if (adapter == null)
                return;

            adapter.OnTakeDamage(_damage);

            //Destroy(other.gameObject); // �� ����
            Destroy(gameObject); // �Ѿ� ����
        }        
    }
}
