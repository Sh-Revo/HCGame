using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private Rigidbody _rb;
    private float _currentSpeed;
    private bool _isMouseUp = false;


    void Start()
    {
        //_currentSpeed = _startSpeed;
    }

    void Update()
    {
        if (_isMouseUp)
        {
            Move();
        }


    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseUp()
    {
        _isMouseUp = true;
        _currentSpeed = _startSpeed;
    }

    void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _currentSpeed, Space.World);
        transform.Rotate(Vector3.right * _currentSpeed, Space.World);
        _currentSpeed -= _currentSpeed * Time.deltaTime;
    }
}
