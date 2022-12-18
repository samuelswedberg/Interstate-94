using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns1;
    public GameObject[] obstaclePatterns2;
    public GameObject[] obstaclePatterns3;
    public GameObject[] obstaclePatterns4;
    public bool spawning;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;
    public int stage;

    void Start()
    {
        stage = 1;
    }
    
    void Update()
    {
        if (spawning == true)
        {
            if (timeBtwSpawn <= 0)
            {
                if (stage == 1)
                {
                    int rand = Random.Range(0, obstaclePatterns1.Length);
                    Instantiate(obstaclePatterns1[rand], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

                if (stage == 2)
                {
                    int rand = Random.Range(0, obstaclePatterns2.Length);
                    Instantiate(obstaclePatterns2[rand], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

                if (stage == 3)
                {
                    int rand = Random.Range(0, obstaclePatterns3.Length);
                    Instantiate(obstaclePatterns3[rand], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

                if (stage == 4)
                {
                    int rand = Random.Range(0, obstaclePatterns4.Length);
                    Instantiate(obstaclePatterns4[rand], transform.position, Quaternion.identity);
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

            }
            else
            {
                timeBtwSpawn -= Time.deltaTime;
            }
        }
        
    }
}
