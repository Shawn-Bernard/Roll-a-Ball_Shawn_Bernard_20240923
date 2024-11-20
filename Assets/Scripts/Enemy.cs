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
    public GameObject Player;

    // Start is called before the first frame update
    public void Awake()
    {
        Player = GameObject.Find("Player");
}
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void LateUpdate()
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
        Vector3 Direction = (Player.transform.position - transform.position);
        transform.forward = Direction;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime);
    }
    void Drop()
    {

        Vector3 position = transform.position;
        if (UnityEngine.Random.Range(0,7) == 0)
        {
            GameObject Drop = Instantiate(itemDrops[0], position, Quaternion.identity);
        }
        
        //Making a itemDrop[Battery] at the enemy poitison
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    

}