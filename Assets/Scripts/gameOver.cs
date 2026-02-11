using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public string sceneToLoad;
    public float waitTime;
    public GameObject loadingScreen, loading_done_message;

    private int sceneInt;
    private bool sceneIsReady = false;
    private bool canStart;

    void Start()
    {
        loadingScreen.SetActive(true);
        int sceneInt = PlayerPrefs.GetInt("level");
        sceneToLoad = "loop" + sceneInt;

        StartCoroutine(prepAndWaitNextLoop());
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
}

