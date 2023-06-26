using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float ExplosionRadius = 7f;
    public int Damage = 50;


    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.collider.CompareTag("Player")) {
            Collider2D[] objects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), ExplosionRadius);

            foreach (Collider2D exploded in objects) {
                if (exploded.GetComponent<Rigidbody2D>() != null) {
                    exploded.GetComponent<Rigidbody2D>().AddForce((exploded.transform.position - transform.position).normalized * 200f);

                    if (exploded.GetComponent<Enemy>() != null) {
                        exploded.GetComponent<Enemy>().TakeDamage(Damage);
                    }

                    if (exploded.GetComponent<PlayerControler>() != null) {
                        exploded.GetComponent<PlayerControler>().TakeDamage(Damage);
                    }
                }
            }

            Destroy(this.gameObject);
        }
    }
}
