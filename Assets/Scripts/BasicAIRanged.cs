using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIRanged : MonoBehaviour
{
    public GameObject player;
    private Vector2 target;
    private Vector3 bulletSpawn;
    public float vel;
    public PlayerHealth _health;
    public GameObject bullet;
    public int damage = 5;
    public Transform playerTransform;
    Transform tf;
    public Transform BulletRespawn;
    private float ShootCd;
    public float setShootCd;
    public float StopDistance;
    public WeaponDTO weaponDTO;
    private Vector3 direction;

    private void Start()
    {
        _health = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        target = new Vector2(playerTransform.position.x, playerTransform.position.y);
        ShootCd = setShootCd;

        tf = GetComponent<Transform>();

        bulletSpawn = BulletRespawn.position;
    }

    void Action()
    {
        if (CanMove())
        {
            Move();
        }
        else
            Shoot();
    }

    private void Move()
    {
        transform.position =
            Vector2.MoveTowards(this.transform.position, player.transform.position, vel * Time.deltaTime);
    }

    // protected virtual float ApplyAccuracy(float angleZ)
    // {
    //     float weaponAngleAccuracy = 10f * (1f - Mathf.Clamp01(1));
    //     angleZ += Random.Range(-weaponAngleAccuracy, weaponAngleAccuracy);
    //     Debug.Log($"{weaponAngleAccuracy} {angleZ}");
    //     return angleZ;
    // }

    private void Shoot()
    {
        if (ShootCd <= 0)
        {
            BulletController bullet = Factory.CreateBullet();
            bullet.SetTransform(BulletRespawn.position, BulletRespawn.rotation.z);
            bullet.SetDTO(weaponDTO);
            
            var moveDirection = (playerTransform.position - transform.position).normalized * weaponDTO.BulletSpeed;
            
            bullet.GetComponent<BulletController>().SetTransform(bulletSpawn, moveDirection.z);

            ShootCd = setShootCd;
        }
        else
            ShootCd -= Time.deltaTime;
    }


    void Update()
    {
        direction = new Vector2(playerTransform.position.x - transform.position.x,
            playerTransform.position.y - transform.position.y);
        transform.up = direction;
        Action();
    }

    private bool CanMove()
    {
        return Vector2.Distance(transform.position, playerTransform.position) > StopDistance;
    }
}