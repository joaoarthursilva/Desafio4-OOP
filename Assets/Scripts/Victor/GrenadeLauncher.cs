using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{
    public override WeaponType Type { get { return WeaponType.RocketLauncher; } }

    public float range, detonatetimer;

    protected override void FireWeapon()
    {
        Grenade bullet = Factory.CreateGrenade();
        float z = ApplyAccuracy(tf.rotation.eulerAngles.z);
        bullet.SetTransform(BulletRespawn.position, z);
        bullet.SetDTO(weaponDTO);
        bullet.range = range;
        bullet.DetonateTimer = detonatetimer;
    }

    public override void SetDTO(WeaponDTO dto)
    {
        base.SetDTO(dto);

        GrenadeDTO wdto = dto as GrenadeDTO;
        if (dto != null)
        {
            range = wdto.Range;
            detonatetimer = wdto.DetonateTimer;
        }
    }
}
