using UnityEngine;
using System.Collections;

public class AttackMechanics : MonoBehaviour {
    Animator anim;
    WeaponMechanics weaponMechanics;

    void Start()
    {
        anim = GetComponent<Animator>();
        weaponMechanics = GetComponentInChildren<WeaponMechanics>();
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
            weaponMechanics.attack();

        }
    }
}
