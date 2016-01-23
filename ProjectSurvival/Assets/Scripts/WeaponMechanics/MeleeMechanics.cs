using UnityEngine;
using System.Collections;

public class MeleeMechanics : WeaponMechanics {

    public override void attack()
    {
        hitBoxList[0].meleeAttack();
    }
}
