using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float x;
    private float y;
    public float sensitivity = -1f;
    private Vector3 rotate;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x, y * sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;
    }
    // Update is called once per frame
    void LateUpdate()
    {
       
       transform.position = player.transform.position + offset;
      
    }
    
}
