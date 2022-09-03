using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private LineRenderer _lineRenderer;
    private Transform _newPosition;
    bool _isMouseDown = false;
    private float _currentSpeed;
    private bool _isMouseUp = false;
    private Vector3 _dir;

    void Start()
    {
        _lineRenderer.positionCount = 2;
        //_currentSpeed = _startSpeed;

    }

    void Update()
    {
        _newPosition = _startPosition;
        _lineRenderer.SetPosition(0, _newPosition.position);
        //Debug.Log(_isMouseDown);
        if (_isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 8.5f;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            SetStrip(mousePosition);
            _dir = mousePosition - _newPosition.position;

            //Debug.Log(mousePosition.x + " " + mousePosition.y + " " + mousePosition.z);
        }
        else
        {
            ResetLine();
        }
        if (_isMouseUp)
        {
            Move();
        }

    }

    private void OnMouseDown()
    {
        _isMouseDown = true;
    }

    private void OnMouseUp()
    {
        _isMouseUp = true;
        _isMouseDown = false;
        _currentSpeed = _startSpeed;
        
    }

    void Move()
    {
        //Debug.Log("dir2 " + direction);
        Vector3 rotate = _dir;
        
        transform.Translate(_dir * Time.deltaTime * _currentSpeed, Space.World);
        //transform.Rotate(rotate * _currentSpeed, Space.World);
        //Quaternion lookRotation = Quaternion.LookRotation(_dir);
        //Vector3 rotation = Quaternion.Lerp(_startPosition.rotation, lookRotation, Time.deltaTime * _currentSpeed).eulerAngles;
        //transform.Rotate(Vector3.right * _currentSpeed, Space.World);
        //_startPosition.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        _currentSpeed -= _currentSpeed * Time.deltaTime;
        if (_currentSpeed < 0.5)
        {
            _currentSpeed = 0;
        }
        //Debug.Log("Speed = " + _currentSpeed);
    }
    void SetStrip(Vector3 target)
    {
        _lineRenderer.SetPosition(1, target);
    }

    private void ResetLine()
    {
        SetStrip(_startPosition.position);
    }

}
