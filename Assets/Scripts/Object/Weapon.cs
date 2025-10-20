using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab; //�Ѿ� ��簡������
    [SerializeField] private Transform _shootPoint; //�߻� ��ġ
    [SerializeField] private float _shootRate = 0.2f; //���� �ӵ�

    private float _nextShootTime = 0f;
    
    public void TryShoot()
    {
        //�ʹ� ���� �߻� ����
        if (Time.time >= _nextShootTime)
        {
            Shoot();
            _nextShootTime = Time.time + _shootRate;
        }
    }

    private void Shoot()
    {
        //���� Ȯ��
        if (_bulletPrefab == null || _shootPoint == null)
        {
            return;
        }
        //�Ѿ� ����
        GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
