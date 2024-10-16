using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorPlayer : MonoBehaviour
{
    public Transform Player;
    public float Speed = 5f;
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        
        transform.RotateAround(Player.position, Vector3.up, mouseX * Speed );
        transform.position = Player.position;

        

    }
}
