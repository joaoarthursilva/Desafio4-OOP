using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public Slider lifeBar, ammoReload;
    public TextMeshProUGUI ammo;

    private void Update()
    {
        UpdateAmmo();
        UpdateLife();

    }

    public void UpdateAmmo()
    {

        //if (PlayerAmmo <=0)
        //{ 
        //  float timer = 1f;
        //  timer -= Time.deltaTime;
        //  ammoReload.gameObject.SetActive(true);
        //  ammoReload.value = timer;
        //  return;
        //}

        //ammoReload.gameObject(false);        
        //ammo.text = PlayerAmmo
    }

    public void UpdateLife()
    {
        //lifeBar.value = playerlife;
    }
}
