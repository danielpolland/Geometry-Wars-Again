using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] possibleenemies;
    public float spawntime = 2;

   
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawntime, spawntime);
    }

    void SpawnEnemy()
    { int index = Random.Range(0, possibleenemies.Length);
        Instantiate(possibleenemies[index], transform.position, Quaternion.identity);
    }

}
