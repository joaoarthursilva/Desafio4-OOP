using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : BulletController
{
    public float ExplosionRadius = 7f;
    public int Damage;

    public void SetDamage(WeaponDTO dto)
    {
        Damage = dto.Damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),
                ExplosionRadius);

            foreach (Collider2D exploded in objects)
            {
                if (exploded.GetComponent<Rigidbody2D>() != null)
                {
                    exploded.GetComponent<Rigidbody2D>()
                        .AddForce((exploded.transform.position - transform.position).normalized * 200f);

                    if (exploded.GetComponent<EnemyHealth>() != null)
                    {
                        exploded.GetComponent<EnemyHealth>().DealDamage(Damage);
                    }

                    if (exploded.GetComponent<PlayerController>() != null)
                    {
                        exploded.GetComponent<PlayerHealth>().TakeDamage(Damage);
                        Debug.Log("DanoNoPlayer");
                    }
                }
            }

            Destroy(this.gameObject);
        }
    }
}