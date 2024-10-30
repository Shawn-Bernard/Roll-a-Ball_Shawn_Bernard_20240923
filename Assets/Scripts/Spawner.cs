using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemy;
    
    public float minimumSpawnTime;
    public float maximumSpawnTime;
    public float timeUntillSpawn;

    public int maximumAmountOfEnemies = 10;



    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntillSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntillSpawn -= Time.deltaTime;
        if (timeUntillSpawn <= minimumSpawnTime)
        // If TUS is less than or MST & enemy count is less than or equal to axEnemy
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            SetTimeUntillSpawn();
        }
        
    }

    private void SetTimeUntillSpawn()
    {
        timeUntillSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
        // Setting timeUntillSpawn with a random range between(MinST & MaxST
    }
}
