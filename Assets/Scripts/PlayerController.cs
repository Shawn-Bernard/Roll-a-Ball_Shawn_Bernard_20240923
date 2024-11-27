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
    public int PickUpcount;
    public TextMeshProUGUI countText;
    public GameObject winTextCount;
    public GameObject Menu;

    [Header("FlashLight Settings")]
    public GameObject flashlight;

    public TMP_Text FlashUI;
    public TMP_Text Controls;

    public float lifeTime = 100;
    public int batteries = 0;
    public int MaxBatteries = 5 ;
    public int DrainSpeed;

    private bool Light;
    private bool off;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextCount.SetActive(false);

        off = true; // Setting off to true
        flashlight.SetActive(false);// Setting the game object "flashlight" to false  
    }
    void Update()
    {
        LightSwitch();
        LightUI();
        Movement();
        death();


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
            Destroy(other.gameObject);//Destroying other object(Pickups)
            count++;
            SetCountText();
        }
        if (other.gameObject.tag == "Battery")
        {
            Destroy(other.gameObject);//Destroying other object(Battery)
            batteries++;//Adding one battery
        }
        if (other.gameObject.tag == "Storage")
        {
            Destroy(other.gameObject);//Destroying other object(storage)
            MaxBatteries++;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            lifeTime--;
        }
    }

    void SetCountText()
    {
        countText.text = $"Count:{count}/{PickUpcount}";
        if (count >= PickUpcount)
        {
            winTextCount.SetActive(true);
        }
    }
    void LightUI()
    {
        FlashUI.text = $"Batteries [{batteries}/{MaxBatteries}]  Battery {lifeTime.ToString("0")}%";
        Controls.text = $"Off/On [F] Reload [R]";
            
        //Showing the amount of batteries & converting the lifeTime to only show whloe numbers
    }
    void death()
    {
        if (batteries == 0 && lifeTime == 0)
        {
            gameObject.SetActive(false);
        }
    }
    void LightSwitch()
    {
        if (Input.GetButtonDown("FlashLight") && Light == false)// This will play if button "f" is pressed & the light is off
        {
            flashlight.SetActive(true);// Setting the game object to true with the light
            Light = true;
        }

        else if (Input.GetButtonDown("FlashLight") && Light == true)// This will play if button "f" is pressed & the light is on
        {
            flashlight.SetActive(false);
            Light = false;
        }

        if (Light == true) // If the flashlight is on 
        {
            lifeTime -= 2 * Time.deltaTime;// This will drain the lifetime by 1 * time.deltatime
        }

        if (lifeTime <= 0) // if LifeTime (battery power) is less than or equal to 0 
        {
            flashlight.SetActive(false);
            Light = true;
            lifeTime = 0;// Setting lifeTime to 0 so it doesn't go under 0
        }
        

        if (lifeTime >= 100)// If LifeTime is greater than or equal to 100 do this
        {
            lifeTime = 100;// Sets the LifeTime to 100 so it doesn't go over 100 
        }

        if (Input.GetButtonDown("Reload") && batteries >= 1)//if "r" is pressed & batteries is greater than or equal 1
        {
            flashlight.SetActive(true);
            Light = true;
            lifeTime += 50;// Adds to the lifeTime by whatever number put
            batteries--;// takes away one batteries
        }

        if (batteries == 0)// If batteries is equal to 0 do this
        {
            batteries = 0;// setting batteries to 0 so we don't go under 0
        }
        if (batteries > MaxBatteries)
        {
            batteries = MaxBatteries;
        }
    }
}