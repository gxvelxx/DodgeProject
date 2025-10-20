using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputComponent : MonoBehaviour
{
    private float _horInput;
    private float _verInput;

    public float HorInput => _horInput;
    public float VerInput => _verInput;

    public bool IsShootingKeyPressed()
    {
        return Input.GetKey(KeyCode.Space);
    }

    void Update()
    {
        //�ε巯�� ����
        //GetAxis+(Raw)�� ���ָ� �ȹ̲�����
        _horInput = Input.GetAxisRaw("Horizontal"); // Ű�Է� A, D
        _verInput = Input.GetAxisRaw("Vertical"); // Ű�Է� W, S

        //Debug.Log($"HorInput = {_horInput}");
        //Debug.Log($"VerInput = {_verInput}");
    }
}