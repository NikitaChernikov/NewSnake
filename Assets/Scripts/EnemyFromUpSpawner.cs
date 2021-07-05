using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFromUpSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    float randX;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    float nextSpawn = 0.0f;

    private void Update()
    {

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.6f, 2.6f);
            whereToSpawn = new Vector2(randX, this.transform.position.y);
            GameObject newEnemy = Instantiate(enemy, whereToSpawn, Quaternion.identity) as GameObject;
        }
    }
}
