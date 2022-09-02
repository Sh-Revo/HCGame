using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float startSpeed;
    private float currentSpeed;
    private int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    private float value = 100;
    bool isMouseDown = false;

    void Start()
    {
        currentSpeed = startSpeed;
    }

    void Update()
    {
        //if (isMouseDown)
        //{

        //}
        //else
        //{
        //}
        value -= Time.deltaTime * 5;
        while (value > 0)
        {
            transform.position += transform.forward * currentSpeed * Time.deltaTime;
            currentSpeed /= 10;
            Debug.Log("Zero");
        }
    }

    private void OnMouseDown()
    {
        isMouseDown = true;
    }

    private void OnMouseUp()
    {
        isMouseDown = false;
        //currentSpeed = startSpeed;
        //Move();
    }

    void Move()
    {
        while (currentSpeed > 0)
        {
            transform.position += transform.forward * currentSpeed * Time.deltaTime;
            currentSpeed /= 10;
        }
        Debug.Log("Speed = " + currentSpeed);
    }
}
