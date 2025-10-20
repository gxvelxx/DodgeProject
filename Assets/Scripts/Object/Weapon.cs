using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab; //총알 모양가져오기
    [SerializeField] private Transform _shootPoint; //발사 위치
    [SerializeField] private float _shootRate = 0.2f; //연사 속도

    private float _nextShootTime = 0f;
    
    public void TryShoot()
    {
        //너무 빠른 발사 방지
        if (Time.time >= _nextShootTime)
        {
            Shoot();
            _nextShootTime = Time.time + _shootRate;
        }
    }

    private void Shoot()
    {
        //장착 확인
        if (_bulletPrefab == null || _shootPoint == null)
        {
            return;
        }
        //총알 생성
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
