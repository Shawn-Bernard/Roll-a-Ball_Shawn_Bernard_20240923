using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    //public GameObject Player;
    
    float minimumSpawnTime = 20;
    float maximumSpawnTime = 30;
    public float timeUntillSpawn;

    



    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntillSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 distance = (transform.position - Player.transform.position);
        
        timeUntillSpawn -= Time.deltaTime;
        if (timeUntillSpawn <= 0)
        // If TUS is less than or MST & enemy count is less than or equal to axEnemy
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
            SetTimeUntillSpawn();
        }
        
    }

    private void SetTimeUntillSpawn()
    {
        //timeUntillSpawn = maximumSpawnTime;
        timeUntillSpawn = Random.RandomRange(minimumSpawnTime, maximumSpawnTime);
        // Setting timeUntillSpawn with a random range between(MinST & MaxST
    }
}
