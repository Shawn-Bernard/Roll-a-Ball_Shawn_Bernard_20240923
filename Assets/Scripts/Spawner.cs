using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject Enemy;
    

    public float minimumSpawnTime;

    public float maximumSpawnTime;

    public float timeUntillSpawn;



    // Start is called before the first frame update
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

    private void SetTimeUntillSpawn()
    {
        timeUntillSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
