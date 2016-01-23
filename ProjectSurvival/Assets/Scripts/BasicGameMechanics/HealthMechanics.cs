using UnityEngine;
using System.Collections;

public class HealthMechanics : MonoBehaviour {
    public float maxHealth = 100;

    bool isDead;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    protected virtual void deathLogic()
    {
        isDead = true;
    }

    public void decreaseHealth(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 && !isDead)
        { 
            deathLogic();
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
            deathLogic();
        }
    }
}
