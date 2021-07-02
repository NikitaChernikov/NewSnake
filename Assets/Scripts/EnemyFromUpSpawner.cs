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

    //public Collider2D[] colliders;
    //public float radius;

    private void Update()
    {

        //bool canSpawnHere;

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.6f, 2.6f);
            whereToSpawn = new Vector2(randX, this.transform.position.y);
            //canSpawnHere = PreventSpawnOverlap(whereToSpawn);
            GameObject newEnemy = Instantiate(enemy, whereToSpawn, Quaternion.identity) as GameObject;
            /*if (canSpawnHere)
            {
                GameObject newFood = Instantiate(food, whereToSpawn, Quaternion.identity) as GameObject;
            }*/
        }
    }

    /*bool PreventSpawnOverlap(Vector3 whereToSpawn)
    {
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.x;
            float height = colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.x - width;
            float rightExtent = centerPoint.x + width;
            float lowerExtent = centerPoint.y - height;
            float upperExtent = centerPoint.y + height;

            if (whereToSpawn.x >= leftExtent && whereToSpawn.x <= rightExtent)
            {
                if (whereToSpawn.y >= lowerExtent && whereToSpawn.y <= upperExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }*/
}
