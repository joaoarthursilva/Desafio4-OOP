using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public static BulletController BulletPrefab;
    public static Missile MissilePrefab;
    public static Grenade grenadeprefab;

    private void Awake()
    {
        BulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");
        MissilePrefab = Resources.Load<Missile>("Prefabs/Missile");
        grenadeprefab = Resources.Load<Grenade>("Prefabs/Victor/grenade");
    }

    public static BulletController CreateBullet()
    {
        BulletController go = Instantiate<BulletController>(BulletPrefab);
        return go;
    }

    public static Missile CreateMissile()
    {
        Missile go = Instantiate<Missile>(MissilePrefab);
        return go;
    }

    public static Grenade CreateGrenade()
    {
        Grenade go = Instantiate<Grenade>(grenadeprefab);
        return go;
    }
}