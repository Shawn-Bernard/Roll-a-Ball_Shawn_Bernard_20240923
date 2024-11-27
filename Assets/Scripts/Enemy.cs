using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    

    public List<GameObject> itemDrops = new List<GameObject>();
    // Making a public list of itemDrops thta can be added in unity
    public NavMeshAgent enemy;
    public GameObject player;
    float range = 6f;
    public Vector3 target;
    // Start is called before the first frame update
    public void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
}
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        Follow();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            Destroy(gameObject);
            Drop();
        }
    }
    void Follow()
    {
        
        //enemy.speed = speed * Time.deltaTime;
        Vector3 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance <= range)
        {
            enemy.SetDestination(player.transform.position);
        }
        else if (enemy.remainingDistance <= enemy.stoppingDistance) // If done moving
        {
            //Throwing is my target vector
            if (Randomtarget(ref target))//if true do this
            {
                enemy.SetDestination(target);// using whatever vector it spits out by ref
            }
        }
    }
    bool Randomtarget(ref Vector3 newtarget)
    {
        Vector3 randTarget = Random.insideUnitSphere * range;// Random target inside a sphere unit and making it the size of range
        NavMeshHit hit;
        //taking randtarget, puting out my hit on mesh with the distance of range and checking all areas on mesh
        if (NavMesh.SamplePosition(randTarget, out hit, range, NavMesh.AllAreas))
        {
            newtarget = hit.position;//making my target 
            return true;
        }
        else
        {
            return false;
        }
    }
    void Drop()
    {

        Vector3 position = transform.position;
        if (UnityEngine.Random.Range(0,6) == 0 || UnityEngine.Random.Range(0, 7) == 2)
        {
            GameObject Drop = Instantiate(itemDrops[0], position, Quaternion.identity);
        }
        
        //Making a itemDrop[Battery] at the enemy poitison
    }
    

}