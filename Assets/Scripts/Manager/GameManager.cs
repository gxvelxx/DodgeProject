using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool _isPlaying = false;
    
    public bool IsPlaying { get { return _isPlaying; } }

    //���� ������ ���������� ���θ� ��ȯ�ϴ� �Լ�
    public void ChangeGameState()
    {
        _isPlaying = !_isPlaying;
    }
}
