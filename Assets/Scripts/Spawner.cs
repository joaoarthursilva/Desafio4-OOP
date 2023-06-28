using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;

    void Start()
    {
        StartCoroutine(EnemySpawn1());
        StartCoroutine(EnemySpawn2());
    }
 
    IEnumerator EnemySpawn1()
    {
        while(true)
        {
            Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(enemy1, enemyspawn, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }

    IEnumerator EnemySpawn2()
    {
        while (true)
        {
            Vector3 enemyspawn = new Vector3(Random.Range(-8f, 8f), 7f, 0);
            Instantiate(enemy2, enemyspawn, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }

    }

}
