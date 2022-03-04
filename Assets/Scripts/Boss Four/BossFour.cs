using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFour : MonoBehaviour
{
    [SerializeField] GameObject spawners;
    [SerializeField] GameObject hammer;
    int cooldown = 1;
    float timer = 0;
    int angle = 0;
    int score;

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
        else
        {
            GameObject buf = Instantiate(hammer);
            buf.transform.position = transform.position + new Vector3(0, -1.5f, 0);
        }
    }
}
