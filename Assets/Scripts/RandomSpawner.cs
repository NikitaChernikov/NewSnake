using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    float randX, randY;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    float nextSpawn = 0.0f;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-2.6f, 2.6f);
            randY = Random.Range(-4.8f, 4.8f);
            whereToSpawn = new Vector2(randX, randY);
            
            Instantiate(food, whereToSpawn, Quaternion.identity);

            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        Destroy(food);
    }
}
