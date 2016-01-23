using UnityEngine;
using System.Collections;
using System;

public class TestDeathScript : DeathLogic {
    


    public override void characterDeath()
    {
        GetComponent<Rigidbody>().mass = 1;
        GetComponent<Rigidbody>().constraints = 0;
        setIsDead(true);
    }

}
