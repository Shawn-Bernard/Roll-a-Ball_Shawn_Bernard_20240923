using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

      
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            Destroy(gameObject);
        }
    }
    void Follow()
    {
        GameObject P = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(this.transform.position, P.transform.position, 2 * Time.deltaTime);
    }
}
