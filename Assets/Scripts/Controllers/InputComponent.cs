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
        //부드러운 감속
        //GetAxis+(Raw)를 써주면 안미끄러짐
        _horInput = Input.GetAxisRaw("Horizontal"); // 키입력 A, D
        _verInput = Input.GetAxisRaw("Vertical"); // 키입력 W, S

        //Debug.Log($"HorInput = {_horInput}");
        //Debug.Log($"VerInput = {_verInput}");
    }
}