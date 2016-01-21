using UnityEngine;
using System.Collections;

public class MovementMechanics : MonoBehaviour {
    public bool movementOn;
    public bool rotationOn;

    public float movementAcceleration = 10;
    public float rotationAcceleration = 15;

    Vector2 inputVector;


	// Use this for initialization
	void Start () {
        inputVector = Vector2.zero;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        horizontalInput(Input.GetAxisRaw("Horizontal"));
        verticalInput(Input.GetAxisRaw("Vertical"));
        updateRotation();
        updateMovement();
	}

    public void horizontalInput(float h)
    {
        inputVector = new Vector2(h, inputVector.y);
    }

    public void verticalInput(float v)
    {
        inputVector = new Vector2(inputVector.x, v);
    }

    protected virtual void updateRotation()
    {
        if (Mathf.Abs(inputVector.x) < .02f && Mathf.Abs(inputVector.y) < .02f)
        {
            return;
        }

        float y = Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, y, 0), Time.deltaTime * rotationAcceleration);        
    }

    protected virtual void updateMovement()
    {

    }

}
