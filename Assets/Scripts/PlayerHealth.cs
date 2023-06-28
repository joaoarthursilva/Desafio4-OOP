using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health ;
    public int MaxHealth = 50;
    private SpriteRenderer sr;
    private Color _default;
    public bool isDamaged = false;

    private void Start()
    {
        health = MaxHealth;
        sr = GetComponent<SpriteRenderer>();
        _default = sr.color;
    }
    public void TakeDamage(int damage)
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


    public void Update()
    {
       
        if (Input.GetKey(KeyCode.V))
            Debug.Log(string.Format("Hp: {0}", health));

        if (health <= 0)
            Destroy(gameObject);



        if (isDamaged)
        {

            StartCoroutine("SwitchColor");
        }
    }
}
