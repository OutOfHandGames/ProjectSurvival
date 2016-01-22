using UnityEngine;
using System.Collections;

public class CameraCollision : MonoBehaviour {
    CameraFollow cameraFollow;

    Vector3 collisionOffset;
    bool isColliding;

    void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
    }

    void Update()
    {
        Transform playerTransform = cameraFollow.getPlayerTransform();
        float mag = cameraFollow.getOffsetVector().magnitude;

        RaycastHit hit;
        //Debug.DrawLine(playerTransform.position, playerTransform.position - transform.forward * 25);
        Ray ray = new Ray(playerTransform.position, -cameraFollow.getOffsetVector());
        //print("I'm doing stuff");
        if (Physics.Raycast(playerTransform.position, -ray.direction, out hit, mag, LayerMask.NameToLayer("Environment")))
        {
            collisionOffset = hit.point;
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    public bool getIsColliding()
    {
        return isColliding;
    }

    public Vector3 getHitOffset()
    {
        return collisionOffset - cameraFollow.getPlayerTransform().position;
    }
}
