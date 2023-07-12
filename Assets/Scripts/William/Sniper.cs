using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Weapon
{
    public float timer;
    bool holdingfire;
    public float rad;
    public GameObject aim;

    public override WeaponType Type
    {
        get { return WeaponType.Sniper; }
    }

    private void FixedUpdate()
    {
        if (holdingfire)
        {
            aim.SetActive(true);
            timer += Time.fixedDeltaTime;
            if (timer >= rad)
            {
                FireWeapon();
                holdingfire = false;
                timer = 0;
                aim.SetActive(false);
            }

            if (!InputController.FireHold)
            {
                aim.SetActive(false);
                holdingfire = false;
                timer = 0;
            }
        }
    }

    public override void Fire()
    {
        holdingfire = true;
    }
}