using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float speed = 0;
    public float CoolDown = 2f;
    public float Timer;
    //public bool CanJump = true;
    

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextCount;
    
     
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextCount.SetActive(false);
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        rb.AddForce(movementVector);

        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && CoolDown <= 0)
        {
          rb.AddForce(0, 100, 0, ForceMode.Force);
            Timer = CoolDown;

        }


            //if (Input.GetKeyDown(KeyCode.Space) && CanJump <= 0 )
            //{
            //    rb.AddForce(0, 100, 0, ForceMode.Force);
            //    CanJump -= -25;
            //}
            //else
            //{
            //    CoolDown += CanJump + Time.deltaTime;
            //}

        }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
        
        


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if (other.gameObject.CompareTag("SpeedBoost"))
        {
            speed = 20;
        }
        else
        {
            speed = 15;
        }

        if (other.gameObject.tag == "JumpPad")
        {
            rb.AddForce(0, 500, 0, ForceMode.Force);
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winTextCount.SetActive(true);
        }
    }
}
