using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlashLightController : MonoBehaviour
{
    
    public GameObject flashlight;
    
    public TMP_Text text;

    public TMP_Text batteryText;

    public float lifeTime = 100;

    public float batteries = 0;

    private bool on;
    private bool off;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        off = true;
        flashlight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LightSwitch();
    }
    void LightSwitch()
    {
        if (Input.GetButtonDown("f") && off)
        {
            flashlight.SetActive(true);
            on = true;
            off = false;
            //flashlight.SetActive(true);
        }
        else if (Input.GetButtonDown("f") && on)
        {
            flashlight.SetActive(false);
            on = false;
            off = true;
            //flashlight.SetActive(false);
        }
    }
    void LightUI()
    {
        text.text = lifeTime.ToString("0") + "%";
        batteryText.text = batteries.ToString();
    }
}
