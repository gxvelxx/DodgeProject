using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    //연결 꼭 하자
    //private void Start()
    //{
    //    if (_weapon == null)
    //    {
    //        _weapon = GetComponentInChildren<Weapon>();            
    //    }
    //}

    private void Update()
    {
        HandleShooting();
    }

    private void HandleShooting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _weapon.TryShoot();
        }
    }
}
