using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAttackSpawnerBossFour : MonoBehaviour
{

    int cooldown = 1;
    float timer = 0;
    [SerializeField] GameObject gear;
    int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = FindObjectOfType<PlayerInfinity>().GetScore();
        if (score < FindObjectOfType<PlayerInfinity>().winScore)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                GameObject buf = Instantiate(gear);
                buf.transform.position = transform.position;
                buf.transform.rotation = transform.rotation;
                timer = 0;
            }
        }
    }
}
