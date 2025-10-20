using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class MoveComponent : MonoBehaviour
{
    [SerializeField] private GameObject _movingPlane;   // 배경을 담을거
    [SerializeField] private float _moveSpeed = 80f;
    [SerializeField] private float _xBoundValue = 2f;
    [SerializeField] private float _zBoundValue = 5f;
    
    private InputComponent _inputComponent;
    private Vector3 _minWorldBounds;
    private Vector3 _maxWorldBounds;

    private Vector3 _playerExtents;

    private void Start()
    {
        _inputComponent = GetComponent<InputComponent>();

        //맵이탈 제한
        SphereCollider playerCollider = GetComponent<SphereCollider>();
        if (playerCollider != null)
        {
            _playerExtents = playerCollider.bounds.extents;
        }
        
        if(_movingPlane != null)
        {
            Bounds planeBounds = _movingPlane.GetComponent<MeshRenderer>().bounds;

            _minWorldBounds = planeBounds.center - planeBounds.extents;
            _maxWorldBounds = planeBounds.center + planeBounds.extents;
        }
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        //현재 게임이 진행중이지 않으면 움직이지 않도록
        //if (GameManager.Instance.IsPlaying == false)
        //    return;        

        //X, Y, Z 정규화
        Vector3 inputVec = new Vector3(_inputComponent.HorInput, 0f, _inputComponent.VerInput).normalized;
        //환경마다 다르기 때문에 1/프레임을 해줘야 어느 환경에서든 일치
        Vector3 deltaMovement = _moveSpeed * Time.deltaTime * inputVec;
        Vector3 nextPosition = transform.position + deltaMovement;

        float xGap = _xBoundValue * _playerExtents.x;
        float zGap = _zBoundValue * _playerExtents.z;

        //맵이탈 제한
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minWorldBounds.x + xGap, _maxWorldBounds.x - xGap);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _minWorldBounds.z + zGap, _maxWorldBounds.z - zGap);

        transform.position = nextPosition;
    }
}
