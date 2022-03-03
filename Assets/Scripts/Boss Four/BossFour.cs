using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFour : MonoBehaviour
{
    [SerializeField] GameObject spawners;
    int cooldown = 1;
    float timer = 0;
    int angle = 0;
    int score;

    private void Start()
    {
        
    }

    private void Update()
    {
        score = FindObjectOfType<PlayerInfinity>().GetScore();
        if (score < FindObjectOfType<PlayerInfinity>().winScore)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                angle += Random.Range(15, 25);
                spawners.transform.eulerAngles = Vector3.forward * angle;
                timer = 0;
            }
        }
    }

}
