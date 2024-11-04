using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    public List<GameObject> itemDrops = new List<GameObject>();
    // Making a public list of itemDrops thta can be added in unity
    public int Speed;
    private Rigidbody rb;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            Dead();
            Drop();
        }
    }
    void Follow()
    {
        GameObject Player = GameObject.Find("Player");// Finding the player object
        GameObject SafeLight = GameObject.Find("Safe");
        float LightDistance = Vector3.Distance(transform.position, SafeLight.transform.position);
        float PlayerDistance = Vector3.Distance(transform.position, Player.transform.position);
        if (LightDistance < 3)
        {
            rb.AddForce(Vector3.forward);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
            //Moving this(enemy) towards the player position
        }
        
    }
    void Drop()
    {
        GameObject SpeedDrop = GameObject.Find("SpeedDrop");
        Vector3 position = transform.position;
        GameObject Drop = Instantiate(itemDrops[0], position,Quaternion.identity);
        //Making a itemDrop[Battery] at the enemy poitison
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    

}