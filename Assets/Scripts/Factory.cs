using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    static public BulletController BulletPrefab;
    static public Missile MissilePrefab;

    private void Awake()
    {
        BulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");
        MissilePrefab = Resources.Load<Missile>("Prefabs/Missile");
    }

    public static BulletController CreateBullet()
    {
        BulletController go = Instantiate<BulletController>(BulletPrefab);
        return go;
    }

    static public Missile CreateMissile()
    {
        Missile go = Instantiate<Missile>(MissilePrefab);
        return go;
    }
}
