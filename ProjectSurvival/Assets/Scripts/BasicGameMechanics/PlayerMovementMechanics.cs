using UnityEngine;
using System.Collections;

public class PlayerMovementMechanics : MovementMechanics {
    Transform playerCamera;

    protected override void Start()
    {
        base.Start();
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    protected override void Update()
    {
        Vector2 adjustedInputVector = calculateInputVector(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        horizontalInput(adjustedInputVector.x);
        verticalInput(adjustedInputVector.y);
        base.Update();
    }

    Vector2 calculateInputVector(float hInput, float vInput)
    {
        float scale = Mathf.Max(Mathf.Abs(hInput), Mathf.Abs(vInput));
        Vector3 newInput = playerCamera.forward * vInput + playerCamera.right * hInput;
        newInput -= Vector3.up * newInput.y;

        newInput = newInput.normalized * scale;
        return new Vector2(newInput.x, newInput.z);

    }

    
}
