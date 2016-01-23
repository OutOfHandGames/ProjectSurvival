using UnityEngine;
using System.Collections;

public class HealthMechanics : MonoBehaviour {
    public float maxHealth = 100;
    public DeathLogic deathLogic;

    bool isDead;
    private float currentHealth;

    void Start()
    {
        deathLogic = GetComponent<DeathLogic>();
        currentHealth = maxHealth;
    }

    protected virtual void initializeDeathLogic()
    {
        isDead = true;
        if (deathLogic != null)
        {
            deathLogic.characterDeath();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void decreaseHealth(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        { 
            initializeDeathLogic();
        }
    }

    public void increaseHealth(float health)
    {
        currentHealth += health;
    }

    public void setHealth(float health)
    {
        this.currentHealth = health;
        if (currentHealth <= 0 && !isDead)
        {
            initializeDeathLogic();
        }
    }
}
