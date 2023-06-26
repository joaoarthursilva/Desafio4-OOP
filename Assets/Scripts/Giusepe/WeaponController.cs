using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public GameObject SpawnPoint;
    private int WeaponSelected = 1;

    // Update is called once per frame
    void Update()
    {
        SelectWeapon();
        Aim();

        switch (WeaponSelected)
        {
            case 1:
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("arma laser");
                }
                break;
            case 2:
                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("lança misseis");
                }
                break;
            case 3:
                gameObject.GetComponent<Shoot>().ShootMissile();
                break;
        }

        
    }

    private void SelectWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponSelected = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponSelected = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeaponSelected = 3;
        }
    }

    private void Aim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.right, direction);

        transform.eulerAngles = new Vector3(0, 0, angle);
    }

 
    
}


