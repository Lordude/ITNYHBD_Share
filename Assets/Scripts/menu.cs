using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class menu : MonoBehaviour
{
    public GameObject loadingscreen, menuObj, settingsObj, creditObj, loading_done_message, blackScreen, content_warning;
    public string sceneName1, sceneToLoad;
    public Button continueButton;
    public TextMeshProUGUI textmeshPro;
    public bool canStart, sceneIsReady, warningMessageActive;
    public int timeToWait1, timeToWait2;
    private bool alreadyPlayed;


    void Start()
    {
        warningMessageActive = true;
        StartCoroutine(showAndCloseWarning());

        if(PlayerPrefs.GetInt("level") > 0)
        {
            continueButton.interactable = true;
            textmeshPro.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("graphics", 2);
            PlayerPrefs.SetInt("resolution", 0);
            PlayerPrefs.SetFloat("mastervolume", 1.0f);
            PlayerPrefs.SetInt("level", 0);
            AudioListener.volume = 1.0f;
            textmeshPro.color = new Color32(80, 80, 80, 255);
            continueButton.interactable = false;
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    
    void Update()
    {
        if(canStart = true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sceneIsReady = true;
            }
        }
    }

    public void continueGame()
    {
        loadingscreen.SetActive(true);
        int sceneInt = PlayerPrefs.GetInt("level");
        sceneToLoad = "loop" + sceneInt;

        StartCoroutine(prepAndWaitNextLoop());
    }

    public void SettingsMenu()
    {
        menuObj.SetActive(false);
        settingsObj.SetActive(true);
    }

    public void playGame()
    {
        alreadyPlayed = true;
        loadingscreen.SetActive(true);
        PlayerPrefs.SetInt("level", 0);
        sceneToLoad = "loop99";

        StartCoroutine(prepAndWaitNextLoop());
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void backToMenu()
    {
        settingsObj.SetActive(false);
        menuObj.SetActive(true);
    }

    public void showCredits()
    {
        menuObj.SetActive(false);
        creditObj.SetActive(true);
    }

    public void backToMenuFromCredits()
    {
        creditObj.SetActive(false);
        menuObj.SetActive(true);
    }

    IEnumerator prepAndWaitNextLoop()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
            if(asyncLoad.progress >= 0.9f)
            {
                canStart = true;
                loading_done_message.SetActive(true);
            }
            if(sceneIsReady == true){
                asyncLoad.allowSceneActivation = true;
            }
        }
    }

    IEnumerator showAndCloseWarning()
    {
        yield return new WaitForSeconds(timeToWait1);
        content_warning.SetActive(false);
        yield return new WaitForSeconds(timeToWait2);
        blackScreen.SetActive(false);
    }
}
