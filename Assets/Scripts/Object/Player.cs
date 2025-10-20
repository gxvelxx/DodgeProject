using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
[RequireComponent(typeof(MoveComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _maxHp; // �ִ�ü��

    private float _curHp; // ����ü��
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

    //���� ���� ��� ȣ���� �Լ�
    public void OnTakeDamage(float damage)
    {
        _curHp -= damage;

        // ü���� 0���� �۾����� �ʰ� ����
        if (_curHp < 0)
            _curHp = 0;

        Debug.Log($"palyerHP = {_curHp}");

        if (_curHp <= 0)
        {
            _curHp = 0;
            GameManager.Instance.ChangeGameState(); // ���ӸŴ��� ����
            //gameObject.SetActive(false);
            return;
        }
    }
}
