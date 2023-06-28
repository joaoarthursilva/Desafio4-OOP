using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject missile;
    public GameObject SpawnPoint;


    public void ShootMissile() {
        if (Input.GetButtonDown("Fire1")) {
            GameObject newGranede = Instantiate(missile, SpawnPoint.transform.position, transform.rotation);
            newGranede.GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * 800f);
        }
    }
}
