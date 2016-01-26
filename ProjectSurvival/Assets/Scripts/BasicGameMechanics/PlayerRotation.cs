using UnityEngine;
using System.Collections;

public class PlayerRotation : RotationMechanics {
    Camera camera;

    protected override void Start()
    {
        base.Start();

        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    protected override void Update()
    {
        updateMouseDirection();

        base.Update();
    }

    void updateMouseDirection()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 direction = Vector3.zero;
        if (Physics.Raycast(ray, out hit, 100, 1))
        {
            direction = hit.point - transform.position;
            direction = direction.normalized;
            
        }
        horizontalDirection(direction.x);
        verticalDirection(direction.z);
    }
}
