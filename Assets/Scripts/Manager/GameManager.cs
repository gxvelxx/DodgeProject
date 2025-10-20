using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool _isPlaying = false;
    
    public bool IsPlaying { get { return _isPlaying; } }

    //현재 게임이 진행중인지 여부를 전환하는 함수
    public void ChangeGameState()
    {
        _isPlaying = !_isPlaying;
    }
}
