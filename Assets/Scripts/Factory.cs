using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    static public BulletController BulletPrefab;

    private void Awake()
    {
        BulletPrefab = Resources.Load<BulletController>("Prefabs/Bullet");
    }

    public static BulletController CreateBullet()
    {
        BulletController go = Instantiate<BulletController>(BulletPrefab);
        return go;
    }
}