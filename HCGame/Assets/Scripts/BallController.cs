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
    private float maxLenght = 10;
    [SerializeField] Rigidbody rb;

    void Start()
    {
        _lineRenderer.positionCount = 2;
    }

    void Update()
    {
        _newPosition = _startPosition;
        _lineRenderer.SetPosition(0, _newPosition.position);
        if (_isMouseDown)
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 14.5f;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition = _startPosition.position + Vector3.ClampMagnitude(mousePosition - _startPosition.position, maxLenght);
            SetStrip(mousePosition);
            _dir = mousePosition - _newPosition.position;
        }
        else
        {
            ResetLine();
        }
        if (_isMouseUp)
        {
            Move(_dir);
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

    void Move(Vector3 _dir)
    {
        Debug.Log("old direction on collision" + _dir);

        if (_currentSpeed < 0.25)
        {
            _currentSpeed = 0;
        }
        transform.Translate(_dir * Time.deltaTime * _currentSpeed, Space.World);
        transform.Rotate(new Vector3(_dir.z, -_dir.y, -_dir.x) * _currentSpeed, Space.World);
        
        _currentSpeed -= _currentSpeed * Time.deltaTime;
        if (_currentSpeed < 0.25)
        {
            _currentSpeed = 0;
        }
    }
    void SetStrip(Vector3 target)
    {
        _lineRenderer.SetPosition(1, target);
    }

    private void ResetLine()
    {
        SetStrip(_startPosition.position);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Vector3 newDirection = Vector3.Reflect(_dir, collision.contacts[0].normal);
        _dir = newDirection;
    }
}
