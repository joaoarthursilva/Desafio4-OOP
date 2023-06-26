using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public float speed;
    //public float lifeTime;
    public GameObject destroyEffect;

    private void Start()
    {
       // Invoke("DestroyTile", lifeTime); 
    
    
    }
    private void Update()
    {
      //  RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance,);
        transform.Translate(transform.up * speed * Time.deltaTime);

    }

   /* void DestroyTile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }*/

        
    
}
