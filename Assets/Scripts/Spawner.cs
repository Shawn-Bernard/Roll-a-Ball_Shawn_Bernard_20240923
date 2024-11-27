using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    
    float minimumSpawnTime = 20;
    float maximumSpawnTime = 30;
    public float timeUntillSpawn;

    void Awake()
    {
        SetTimeUntillSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
        timeUntillSpawn -= Time.deltaTime;
        if (timeUntillSpawn <= 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            SetTimeUntillSpawn();
        }
        
    }

    void SetTimeUntillSpawn()
    {

        timeUntillSpawn = Random.RandomRange(minimumSpawnTime, maximumSpawnTime);
        // Setting timeUntillSpawn with a random range between(MinST & MaxST)
    }
}
