using UnityEngine;
using System.Collections;

public class RotationMechanics : MonoBehaviour {
    public float rotationAcceleration;

    float hInput;
    float vInput;
    float goalYDirection;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        if (Mathf.Abs(hInput) > .01f || Mathf.Abs(vInput) > .01f)
        {
            goalYDirection = updateGoalDirection();
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, goalYDirection, 0), Time.deltaTime * rotationAcceleration);
    }

    float updateGoalDirection()
    {
        return Mathf.Atan2(hInput, vInput) * Mathf.Rad2Deg;
    }

    public void verticalDirection(float vInput)
    {
        this.vInput = vInput;
    }

    public void horizontalDirection(float hInput)
    {
        this.hInput = hInput;
    }

    public void setDirection(float degree)
    {
        goalYDirection = degree;
        hInput = 0;
        vInput = 0;
    }
}
