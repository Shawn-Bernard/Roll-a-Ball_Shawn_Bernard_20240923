using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    [Header("Player Settings")]
    public float speed;

    private float movementX;
    private float movementY;

    private Rigidbody rb;

    private int count;
    public TextMeshProUGUI countText;
    public GameObject TextBox;
    public GameObject winTextCount;

    [Header("FlashLight Settings")]
    public GameObject flashlight;

    public TMP_Text FlashUI;
    public TMP_Text Controls;

    public float lifeTime = 100;
    public int batteries = 0;

    private bool on;
    private bool off;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextCount.SetActive(false);
        TextBox.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;// Locking the mouse because it feels weird without it

        off = true; // Setting off to true
        flashlight.SetActive(false);// Setting the game object "flashlight" to false  
    }
    void Update()
    {
        LightSwitch();// Using a method here because my update would look nasty
        LightUI();
        Movement();
    }
    void FixedUpdate()
    {

    }

    void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();
        rb.AddRelativeForce(movementVector);
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    

    void Movement()
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
        if (other.gameObject.tag == "JumpPad" )
        {
            rb.AddForce(0, 5, 0, ForceMode.VelocityChange);
        }
        if (other.gameObject.tag == "Battery")
        {
            Destroy(other.gameObject);//Destroying other object(Battery)
            batteries++;//Adding one battery
            
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
    void LightUI()
    {
        FlashUI.text = $"Batteries [{batteries}]  Battery {lifeTime.ToString("0")}%";
        Controls.text = $"Off/On [F] Reload [R]";
            
        //Showing the amount of batteries & converting the lifeTime to only show whloe numbers
    }
    void LightSwitch()
    {
        if (Input.GetButtonDown("FlashLight") && off)// This will play if button "f" is pressed & the light is off
        {
            flashlight.SetActive(true);// Setting the game object to true
            on = true;
            off = false;
        }

        else if (Input.GetButtonDown("FlashLight") && on) // Same thing here but reverse
        {
            flashlight.SetActive(false);
            on = false;
            off = true;
        }

        if (on) // If on do this code 
        {
            lifeTime -= 4 * Time.deltaTime;// This will drain the lifetime by 1 * time.deltatime
        }

        if (lifeTime <= 0) // if LifeTime is less than or equal to 0 play this
        {
            flashlight.SetActive(false);
            on = false;
            off = true;
            lifeTime = 0;// Setting lifeTime to 0 so it doesn't go under 0
        }
        

        if (lifeTime >= 100)// If LifeTime is greater than or equal to 100 do this
        {
            lifeTime = 100;// Sets the LifeTime to 100 so it doesn't go over 100 
        }

        if (Input.GetButtonDown("Reload") && batteries >= 1)// this code will play if "r" is pressed & batteries is greater than or equal 1
        {
            flashlight.SetActive(true);
            on = true;
            lifeTime += 50;// Adds to the lifeTime by whatever number put
            batteries--;// takes away one batteries when this is played
        }

        if (batteries == 0)// If batteries is equal to 0 do this
        {
            batteries = 0;// setting batteries to 0 so we don't go under 0
        }
        if (batteries > 5)
        {
            batteries = 5;
        }
    }
}