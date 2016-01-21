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
        verticalInput(Input.GetAxis("Vertical"));
        horizontalInput(Input.GetAxis("Horizontal"));
        base.Update();
    }

    protected override void updateRotation()
    {
        if (Mathf.Abs(getInputvector().x) < .02f && Mathf.Abs(getInputvector().y) < .02f)
        {
            return;

        }

        Vector3 offsetVector = (getInputvector().y * playerCamera.forward + getInputvector().x * playerCamera.right);

        float y = Mathf.Atan2(offsetVector.x, offsetVector.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, y, 0), Time.deltaTime * rotationAcceleration);


    }
}
