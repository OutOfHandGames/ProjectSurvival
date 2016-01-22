using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    public float cameraMaxSpeed = 25;
    public float cameraAcceleration = 12;

    Transform playerTransform;
    Rigidbody rigid;
    Vector3 offsetVector;
    CameraCollision cameraCollision;

    void Start()
    {
        playerTransform = transform.parent;
        transform.parent = null;

        offsetVector = transform.position - playerTransform.position;
        rigid = GetComponent<Rigidbody>();
        cameraCollision = GetComponent<CameraCollision>();
    }

    void Update()
    {
        updateCameraPosition();
    }

    void updateCameraPosition()
    {
        Vector3 offset = offsetVector;
        if (cameraCollision.getIsColliding())
        {
            offset = cameraCollision.getHitOffset();
        }
        Vector3 vel = (-transform.position + playerTransform.position + offset);
        vel *= cameraMaxSpeed;
        rigid.velocity = Vector3.MoveTowards(rigid.velocity, vel, Time.deltaTime * cameraAcceleration);
    }
    

    public Transform getPlayerTransform()
    {
        return playerTransform;
    }

    public Vector3 getOffsetVector()
    {
        return offsetVector;
    }

}
