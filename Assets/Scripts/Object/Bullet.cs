using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 160f; // 총알 속도
    [SerializeField] private float _bulletTime = 2f; // 총알 유지시간
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
        //앞으로 날아가게 (Z방향)
        transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);
    }

    //총알 충돌처리
    private void OnTriggerEnter(Collider other)
    {
        //적과 충돌하면 제거
        if (other.CompareTag("Enemy"))
        {
            ITakeDamageAdapter adapter = other.GetComponent<ITakeDamageAdapter>();

            if (adapter == null)
                return;

            adapter.OnTakeDamage(_damage);

            //Destroy(other.gameObject); // 적 제거
            Destroy(gameObject); // 총알 제거
        }        
    }
}
