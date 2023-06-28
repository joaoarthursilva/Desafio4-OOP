using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : BulletController
{
    public float DetonateTimer;
    bool stuck;
    public float range;

    protected override void Update()
    {
        float currentDistance = Vector3.Distance(tf.position, StartPosition);
        if (Speed > 0)
            Speed -= currentDistance;
        if (currentDistance >= Distance)
            stuck = true;

        if (stuck)
        {
            DetonateTimer -= Time.deltaTime;
            Speed = 0;
            rb.velocity = Vector2.zero;
        }

        if (DetonateTimer < 0)
            Detonate();

        if (!(FindObjectOfType<PlayerController>().CurrentWeapon is GrenadeLauncher))
        {
            Detonate();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        stuck = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.parent = col.transform;
    }

    public void Detonate()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, range);

        ExplosionVisual();

        foreach (var col in cols)
        {
            if (col.GetComponent<Grenade>())
            {
                col.GetComponent<Grenade>().stuck = true;
                col.GetComponent<Grenade>().DetonateTimer = 0.1f;
            }
        }

        Destroy(gameObject);
    }

    void ExplosionVisual()
    {
        GameObject go = new GameObject();
        go.transform.position = transform.position;
        var s = go.AddComponent<SpriteRenderer>();
        s.sprite = GetComponent<SpriteRenderer>().sprite;
        s.color = (Color.red + Color.yellow) / 2;
        go.transform.localScale *= range;
        Destroy(go, .5f);
    }
}