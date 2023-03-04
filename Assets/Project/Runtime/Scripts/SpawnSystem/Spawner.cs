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
                    Spawn1();
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

                if (stage == 2)
                {
                    int rand = Random.Range(0, 1);
                    if(rand == 0)
                        Spawn1();
                    else if(rand == 1)
                        Spawn2();
                    //Debug.Log("Rand: " + rand);
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

                if (stage == 3)
                {
                    int rand = Random.Range(0, 2);
                    if(rand == 0)
                        Spawn1();
                    else if(rand == 1)
                        Spawn2();
                    else if(rand == 2)
                        Spawn3();
                    //Debug.Log("Rand: " + rand);
                    timeBtwSpawn = startTimeBtwSpawn;

                    if (startTimeBtwSpawn > minTime)
                    {
                        startTimeBtwSpawn -= decreaseTime;
                    }
                }

                if (stage == 4)
                {
                    int rand = Random.Range(0, 3);
                    if(rand == 0)
                        Spawn1();
                    else if(rand == 1)
                        Spawn2();
                    else if(rand == 2)
                        Spawn3();
                    else if(rand == 3)
                        Spawn4();
                    //Debug.Log("Rand: " + rand);
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
    public void Spawn1()
    {
        int rand = Random.Range(0, obstaclePatterns1.Length);
        Instantiate(obstaclePatterns1[rand], transform.position, Quaternion.identity);
    }

    public void Spawn2()
    {
        int rand1 = Random.Range(0, obstaclePatterns2.Length);
        Instantiate(obstaclePatterns2[rand1], transform.position, Quaternion.identity);
    }

    public void Spawn3()
    {
        int rand = Random.Range(0, obstaclePatterns3.Length);
        Instantiate(obstaclePatterns3[rand], transform.position, Quaternion.identity);
    }

    public void Spawn4()
    {
        int rand = Random.Range(0, obstaclePatterns4.Length);
        Instantiate(obstaclePatterns4[rand], transform.position, Quaternion.identity);
    }


}
