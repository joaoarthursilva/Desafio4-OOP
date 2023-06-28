using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public Slider enemyLife;

    private void Update()
    {
        UpdateEnemyLife();
    }
    public void UpdateEnemyLife()
    {
      //  enemyLife.value = EnemyLife;
    }

}
