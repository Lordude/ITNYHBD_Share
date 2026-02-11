using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loop0Cutscene : MonoBehaviour
{

    public GameObject cutsceneCam, player, loopDoor, playerCam, targetCam, blackScreen;
    public SC_FPSController playerController;
    public float speed;
    public float timeCount;
    public float cutsceneTime;
    public bool sceneIsReady;
    public string sceneName;
    public AudioSource sfxScary;
    public int currentLevel;
    public doorToLoop doorToLoop; 


    void Start()
    {
        PlayerPrefs.SetInt("level", currentLevel);
        StartCoroutine(cutscene());
        StartCoroutine(prepareNextLoop());
    }
    IEnumerator cutscene()
    {
        sfxScary.Play();
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCam.SetActive(false);
    }



    IEnumerator prepareNextLoop()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
            if(asyncLoad.progress >= 0.9f)
            {
                sceneIsReady = true;
            }
            if(sceneIsReady == true){
                if(doorToLoop.readyToLoop){
                
                playerController.enabled = false;
                Transform playerCamTrans = playerCam.GetComponent<Transform>();
                Transform targetCamTrans = targetCam.GetComponent<Transform>();

                playerCam.transform.rotation = Quaternion.Lerp(playerCamTrans.rotation, targetCamTrans.rotation, timeCount );
                playerCam.transform.position = Vector3.Lerp(playerCamTrans.position, targetCamTrans.position, timeCount );
                timeCount = timeCount + Time.deltaTime;
                    if(Vector3.Distance(playerCamTrans.position, targetCamTrans.position) < 0.01f){
                        if( Quaternion.Angle(playerCamTrans.rotation,targetCamTrans.rotation) < 0.01f){
                            asyncLoad.allowSceneActivation = true;
                        }

                    }
                }
            }
        }
        
    }
}
