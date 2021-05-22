using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLaser : PickupItem
{
    public override void Pickup()
    {
        FireGun[] guns = player.GetComponentsInChildren<FireGun>();

        foreach (FireGun gun in guns)
            gun.enabled = false;

        player.GetComponentInChildren<FireRay>().enabled = true;
    }
}
