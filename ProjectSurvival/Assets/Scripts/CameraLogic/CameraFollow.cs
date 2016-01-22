using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float cameraMaxSpeed = 25;
    public float cameraAcceleration = 12;

    Transform playerTransform;
    Rigidbody rigid;
    Vector3 offsetVector;

    void Start()
    {
        playerTransform = transform.parent;
        transform.parent = null;

        offsetVector = transform.position - playerTransform.position;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        updateCameraPosition();
    }

    void updateCameraPosition()
    {
        Vector3 vel = -transform.position + playerTransform.position + offsetVector;
        vel *= cameraMaxSpeed;
        rigid.velocity = Vector3.MoveTowards(rigid.velocity, vel, Time.deltaTime * cameraAcceleration);
    }

}
