using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLightController : MonoBehaviour
{
    
    public GameObject flashlight;
    public GameObject Battery;
    
    public TMP_Text text;

    public TMP_Text batteryText;

    public float lifeTime = 100;

    public int batteries = 0;

    private bool on;
    private bool off;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;// Locking the mouse because it feels weird without it

        off = true; // Setting off to true
        flashlight.SetActive(false);// Setting the game object "flashlight" to false  
    }

    // Update is called once per frame
    void Update()
    {
        LightSwitch();// Using a method here because my update would look nasty
        LightUI(); 
    }
    
    void LightUI()
    {
        text.text = lifeTime.ToString("0") + "%";
        batteryText.text = batteries.ToString();
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
            lifeTime -= 1 * Time.deltaTime;// This will drain the lifetime by 1 * time.deltatime
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
            lifeTime += 50;// Adds to the lifeTime by whatever number put
            batteries--;// takes away one batteries when this is played
        }
        if (Input.GetButtonDown("Reload") && batteries == 0) 
        {
            return;
        }
        if (batteries == 0)// If batteries is equal to 0 do this
        {
            batteries = 0;// setting batteries to 0 so we don't go under 0
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            batteries++;
        }
    }
}
