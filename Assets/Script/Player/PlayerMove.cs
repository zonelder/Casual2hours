using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    public Action<Vector2> PointReached;
    [SerializeField] private float _maxSpeedModule;
    [SerializeField] private Camera _playerCamera;
    private Rigidbody2D _rigid;
    private Queue<Vector2> _targetPoints = new Queue<Vector2>();

    private bool LastTargetAchieved=>_targetPoints.Count==0;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.touches.Length>0 && Input.touches[0].phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            _targetPoints.Enqueue(_playerCamera.ScreenToWorldPoint(Input.mousePosition));
           
        }        
    }

    private void FixedUpdate()
    {
        if (!LastTargetAchieved)
        {
            Move();

        }
    }

    private void Move()
    {
        Vector2 _firstDestination = _targetPoints.Peek();
        _rigid.MovePosition(Vector2.MoveTowards(_rigid.position, _firstDestination,_maxSpeedModule* Time.fixedDeltaTime));
        if(_rigid.position ==_firstDestination)
        {
            PointReached?.Invoke(_targetPoints.Dequeue());
        }
    }
}
