using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{

    PlayerHealth _health;
    EnemyHealth _enemyHealth;
    BasicAIRanged basicAIRanged;
    public int damager = 5;
    public int DamageInimigo = 5;



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            
            _health = collision.gameObject.GetComponent<PlayerHealth>();
            _health.TakeDamage(DamageInimigo);
            Debug.Log("acertou");
            Destroy(gameObject);
        }

        else if (collision.gameObject.CompareTag ("Enemy"))
        {
            _enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            _enemyHealth.DealDamage(damager);
            Destroy(gameObject);
            
        }

    }


}
