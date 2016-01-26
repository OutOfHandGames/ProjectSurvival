using UnityEngine;
using System.Collections;

public class MovementMechanics : MonoBehaviour {
    public bool movementOn = true;
    public float speed = 5; //This will be deleted when root motion is placed back in game
    public float movementAcceleration = 10;

    Rigidbody rigid;
    Animator anim;
    Vector2 inputVector;


	// Use this for initialization
	protected virtual void Start () {
        inputVector = Vector2.zero;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
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

        //////////////////This will not be needed when root motion is added back....////////////////////////////////
        Vector3 goalVelocity = new Vector3(inputVector.x, rigid.velocity.y, inputVector.y) * scale * speed;
        rigid.velocity = Vector3.MoveTowards(rigid.velocity, goalVelocity, Time.deltaTime * movementAcceleration);
    }

}
