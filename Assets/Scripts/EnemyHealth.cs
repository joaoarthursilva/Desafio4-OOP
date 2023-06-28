using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health;
    public int MaxHealth = 50;
    private SpriteRenderer sr;
    private Color _default;
    public bool isDamaged = false;


    private void Start()
    {
        health = MaxHealth;
         sr = GetComponent<SpriteRenderer>();
        _default = sr.color ;
    }
    public void DealDamage (int damage)
    {
       
        health -= damage;
        isDamaged = true;

        
    }


    IEnumerator SwitchColor()
    {
        sr.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(0.1f);
        sr.color = _default;
        isDamaged = false;
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

        if (isDamaged)
        {
          
            StartCoroutine("SwitchColor");
        }
     
    }
}

