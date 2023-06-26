using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    static public BulletController BulletPrefab;
    static public Grenade grenadeprefab;

    private void Awake()
    {
        BulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");
        grenadeprefab = Resources.Load<Grenade>("Prefabs/Victor/grenade");
    }

    static public BulletController CreateBullet()
    {
        BulletController go = Instantiate<BulletController>(BulletPrefab);
        return go;
    }

    static public Grenade CreateGrenade()
    {
        Grenade go = Instantiate<Grenade>(grenadeprefab);
        return go;
    }
}
