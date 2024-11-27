using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inGameMenu : MonoBehaviour
{
    public GameObject Menu;
    bool GamePause = false;
    // Start is called before the first frame update
    private void Awake()
    {
        Paused();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Paused();
        }

    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Paused()
    {
        Cursor.lockState = CursorLockMode.Confined;
        GamePause = true;
        Menu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GamePause = false;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
}
