using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pausemenu, settingsmenu;
    public string menuSceneName;
    public bool toggle; 
    public SC_FPSController playerController;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toggle = !toggle;
            if(toggle == false)
            {
                pausemenu.SetActive(false);
                settingsmenu.SetActive(false);
                AudioListener.pause = false;
                Time.timeScale = 1;
                playerController.enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            if(toggle == true)
            {
                pausemenu.SetActive(true);
                AudioListener.pause = true;
                Time.timeScale = 0;
                playerController.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }    
    }

    public void resumeGame()
    {
        toggle = false;
        pausemenu.SetActive(false);
        AudioListener.pause = false;
        Time.timeScale = 1;
        playerController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void toSettings()
    {
        pausemenu.SetActive(false);
        settingsmenu.SetActive(true);
    }

    public void backToPause()
    {
        pausemenu.SetActive(true);
        settingsmenu.SetActive(false);
    }

    public void quitToMenu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(menuSceneName);
    }

    public void quitToDesktop()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Debug.Log("YOU CANNOT ESCAPE");
        Application.Quit();
    }
}
