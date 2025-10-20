using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private bool _isPlaying = true;
    
    public bool IsPlaying { get { return _isPlaying; } }

    //���� ������ ���������� ���θ� ��ȯ�ϴ� �Լ�
    public void ChangeGameState()
    {
        _isPlaying = !_isPlaying;
    }
}