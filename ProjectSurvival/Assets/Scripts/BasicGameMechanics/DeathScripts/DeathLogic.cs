using UnityEngine;
using System.Collections;

public abstract class DeathLogic : MonoBehaviour {
    public float timeBeforeDestroy = 5;

    float destroyTimer;
    bool isDead;

    void Start()
    {
        destroyTimer = timeBeforeDestroy;
    }


    protected virtual void Update()
    {
        if (isDead)
        {
            destroyTimer = Mathf.MoveTowards(destroyTimer, 0, Time.deltaTime);
            if (destroyTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }


    }

    public void setIsDead(bool isDead)
    {
        this.isDead = isDead;
    }

    public bool getIsDead()
    {
        return this.isDead;
    }

    public abstract void characterDeath();


}
