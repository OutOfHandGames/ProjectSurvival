using UnityEngine;
using System.Collections;

public class MeleeHitbox : MonoBehaviour {
    public float timeActive = .25f;
    public Vector3 forceDirection = new Vector3(0, 0, 1);
    public float hitForce = 25;

    Collider hitCollider;
    bool hitActive;
    float timer;
    
    void Start()
    {
        forceDirection = forceDirection.normalized;
        hitCollider = GetComponent<Collider>();
        hitCollider.enabled = hitActive;
    }

    void Update()
    {
        updateActiveTimer();
        if (timer <= 0)
        {
            hitActive = false;
        }
        hitCollider.enabled = hitActive;
    }

    public void meleeAttack()
    {

        if (!hitActive)
        {
            hitActive = true;
            timer = timeActive;
        }
    }

    void updateActiveTimer()
    {
        timer = Mathf.MoveTowards(timer, 0, Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        Rigidbody colRigid = collider.GetComponent<Rigidbody>();

        if (colRigid != null)
        {
            Vector3 finalForce = Vector3.zero;
            finalForce += transform.forward * forceDirection.z;
            finalForce += transform.right * forceDirection.x;
            finalForce += transform.up * forceDirection.y;

            colRigid.AddForce(finalForce * hitForce);
        }
    }
}
