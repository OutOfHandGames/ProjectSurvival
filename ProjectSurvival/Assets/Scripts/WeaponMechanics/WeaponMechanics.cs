using UnityEngine;
using System.Collections;

public abstract class WeaponMechanics : MonoBehaviour {
    public MeleeHitbox[] hitBoxList;
    RuntimeAnimatorController animatorController;

    public abstract void attack();

}
