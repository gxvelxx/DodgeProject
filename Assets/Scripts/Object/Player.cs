using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _maxHp; // 최대체력

    private float _curHp; // 현재체력
    private InputComponent _inputComponent;
    private MoveComponent _moveComponent;
   
    private void Start()
    {
        SetComponent();
        InitPlayer();
    }

    private void InitPlayer()
    {
        _curHp = _maxHp;
    }

    private void SetComponent()
    {
        _inputComponent = GetComponent<InputComponent>();
        _moveComponent = GetComponent<MoveComponent>();

        if (_weapon == null)
        {
            _weapon = GetComponentInChildren<Weapon>();
            if (_weapon == null)
                return;
        }

        _weapon.SetInput(_inputComponent);
    }

    //공격 받을 경우 호출할 함수
    public void OnTakeDamage(float damage)
    {
        _curHp -= damage;

        // 체력이 0보다 작아지지 않게 고정
        if (_curHp < 0)
            _curHp = 0;

        Debug.Log($"palyerHP = {_curHp}");

        if (_curHp <= 0)
        {
            _curHp = 0;
            GameManager.Instance.ChangeGameState(); // 게임매니저 적용
            //gameObject.SetActive(false);
            return;
        }
    }
}
