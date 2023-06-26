using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    public Transform damagePopUp;

    private void Start()
    {
        DamagePopUpCotroller.Create(damagePopUp, Vector3.zero, 300);
    }
}
