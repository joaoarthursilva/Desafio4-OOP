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
    protected Transform BulletRespawn;
    private float ShootCd;
    public float setShootCd;
    public float StopDistance;
    public float speed;


    private void Start()
    {
        _health = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        target = new Vector2(playerTransform.position.x, playerTransform.position.y);
        ShootCd = setShootCd;

        tf = GetComponent<Transform>();

        bulletSpawn = new Vector2(transform.position.x + 1, transform.position.y + 1);
    }

    void Action()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > StopDistance)
            // isso nao ta funcionando por isso nao ta atirando
        {
            transform.position =
                Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else
            Shoot();
    }

    void Shoot()
    {
        if (ShootCd <= 0)
        {
            // BulletController bullet = Factory.CreateBullet();
            var bullet = Instantiate(this.bullet);
            bullet.GetComponent<BulletController>().SetTransform(bulletSpawn, speed);

            ShootCd = setShootCd;
        }
        else
            ShootCd -= Time.deltaTime;
    }


    void Update()
    {
        transform.position =
            Vector2.MoveTowards(this.transform.position, player.transform.position, vel * Time.deltaTime);
        Vector2 direction = new Vector2(playerTransform.position.x - transform.position.x,
            playerTransform.position.y - transform.position.y);
        transform.up = direction;

        Action();
    }
}