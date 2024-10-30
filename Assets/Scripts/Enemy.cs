using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static List<Enemy> Enemies = new List<Enemy>();
    public List<GameObject> itemDrops = new List<GameObject>();
    // Making a public list of itemDrops thta can be added in unity
    public int Speed;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        
    }
    public void OnDestroy()
    {
        
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
        GameObject P = GameObject.Find("Player");// Finding the player object
        transform.position = Vector3.MoveTowards(this.transform.position, P.transform.position, Speed * Time.deltaTime);
        //Moving this(enemy) towards the player position 
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