using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
    public float rotationAcceleration = 50;
    CameraFollow cameraFollow;
    float goalY;

    void Start()
    {
        cameraFollow = GetComponent<CameraFollow>();
        goalY = transform.eulerAngles.y;
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            goalY += 45;
            cameraFollow.setOffsetVector(Quaternion.AngleAxis(-45, Vector3.up) * cameraFollow.getPlayerTransform().position);

        }
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, goalY, transform.eulerAngles.z), Time.deltaTime * rotationAcceleration);        
    }

    Vector3 calculateNewOffset()
    {
        float mag = cameraFollow.getOffsetVector().magnitude;
        return transform.forward * mag;
    }
}
