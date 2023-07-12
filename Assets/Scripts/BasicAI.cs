using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    public GameObject player;
    public float vel;
    public PlayerHealth _health;
    public int damage = 10;
    public Transform playerTransform;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _health = player.GetComponent<PlayerHealth>();
        playerTransform = player.GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        _health.TakeDamage(damage);
        Destroy(this.gameObject);
    }

    void Update()
    {
        transform.position =
            Vector2.MoveTowards(this.transform.position, player.transform.position, vel * Time.deltaTime);
        Vector2 direction = new Vector2(playerTransform.position.x - transform.position.x,
            playerTransform.position.y - transform.position.y);
        transform.up = direction;
    }
}