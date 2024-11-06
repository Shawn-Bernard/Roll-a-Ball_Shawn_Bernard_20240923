using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;
    public float Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + offset;
        //MouseController();


    }
    void MouseController()
    {
        GameObject Player = GameObject.Find("Player");
        float mouseX = Input.GetAxis("Mouse X");

        transform.RotateAround(Player.transform.position, Vector3.forward, mouseX * Speed);
        transform.position = Player.transform.position + offset;

    }
}
