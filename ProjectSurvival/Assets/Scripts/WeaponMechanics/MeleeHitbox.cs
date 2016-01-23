using UnityEngine;
using System.Collections;

public class MeleeHitbox : MonoBehaviour {
    public float timeActive = .25f;
    public Vector3 forceDirection = new Vector3(0, 0, 1);
    public float hitForce = 25;
    public int damage = 35;

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
        HealthMechanics colHealth = collider.GetComponent<HealthMechanics>();

        if (colHealth != null)
        {
            //print("I made it here");
            Vector3 finalForce = Vector3.zero;
            finalForce += transform.forward * forceDirection.z;
            finalForce += transform.right * forceDirection.x;
            finalForce += transform.up * forceDirection.y;

            colHealth.GetComponent<Rigidbody>().AddForce(finalForce * hitForce);
            colHealth.decreaseHealth(damage);
        }
    }
}
