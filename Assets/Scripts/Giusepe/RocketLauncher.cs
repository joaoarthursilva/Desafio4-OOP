using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public override WeaponType Type { get { return WeaponType.RocketLauncher; } }

    protected override void FireWeapon()
    {
        Missile bullet = Factory.CreateMissile();
        float z = ApplyAccuracy(tf.rotation.eulerAngles.z);
        bullet.SetTransform(BulletRespawn.position, z);
        bullet.SetDTO(weaponDTO);
        bullet.SetDamage(weaponDTO);
    }
}
