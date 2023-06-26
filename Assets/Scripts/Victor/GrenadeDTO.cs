using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Grenade DTO", menuName = "DTO/GrenadeDTO")]
public class GrenadeDTO : WeaponDTO
{
    public float DetonateTimer;
    public float Range;
}
