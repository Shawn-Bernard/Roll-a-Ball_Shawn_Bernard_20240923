using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //public GameObject SpeedBoost;

    // Start is called before the first frame update
    void Start()
    {
       

      
        
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        //Away();

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
        GameObject P = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(this.transform.position, P.transform.position, 2 * Time.deltaTime);
    }
    void Drop()
    {
        GameObject SpeedDrop = GameObject.Find("SpeedDrop");
        Vector3 position = transform.position;
        GameObject Speed = Instantiate(SpeedDrop, position,Quaternion.identity);

    }
    void Dead()
    {
        Destroy(gameObject);

    }

}
