using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon_Small : MeleeUnit
{
    protected override void Start()
    {
        base.Start();

        xpWorth = 1;
        aggroRadius = 150;
        health = 1;
        walkingSpeed = 20;
        damagePerHit = 1;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override string ToString()
    {
        return "Demon_small";
    }

    protected override void death()
    {
        base.death();
        UIManager.IncreaseCurrentKills();
    }
}
