using UnityEngine;
using System.Collections;

public class AttackMechanics : MonoBehaviour {
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        attack(Input.GetButtonDown("Fire1"));
    }

    void attack(bool attackDown)
    {
        if (attackDown)
        {
            anim.ResetTrigger("Attack");
            anim.SetTrigger("Attack");

        }
    }
}
