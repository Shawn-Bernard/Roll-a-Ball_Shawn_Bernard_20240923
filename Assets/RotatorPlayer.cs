using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorPlayer : MonoBehaviour
{
    public Transform Player;
    public float Speed = 5f;
    

    // Update is called once per frame
    void Update()
    {
        RotatorLight();
    }
    void RotatorLight()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.RotateAround(Player.position, Vector3.up, mouseX * Speed);
        transform.position = Player.position;
    }
}