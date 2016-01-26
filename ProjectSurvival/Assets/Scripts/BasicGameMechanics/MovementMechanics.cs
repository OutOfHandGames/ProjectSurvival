using UnityEngine;
using System.Collections;

public class MovementMechanics : MonoBehaviour {
    public bool movementOn = true;

    public float movementAcceleration = 10;

    Animator anim;

    Vector2 inputVector;


	// Use this for initialization
	protected virtual void Start () {
        inputVector = Vector2.zero;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
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

    public Vector2 getInputvector()
    {
        return inputVector;
    }

    protected virtual void updateMovement()
    {
        float scale = Mathf.Max(Mathf.Abs(inputVector.x), Mathf.Abs(inputVector.y));
        inputVector = inputVector.normalized;
        anim.SetFloat("Speed", inputVector.magnitude * scale);
    }

}
