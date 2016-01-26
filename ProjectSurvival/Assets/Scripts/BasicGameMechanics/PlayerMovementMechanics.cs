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
        verticalInput(Input.GetAxisRaw("Vertical"));
        horizontalInput(Input.GetAxisRaw("Horizontal"));
        base.Update();
    }

    
}
