using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro_loop_prep : MonoBehaviour
{
    public GameObject preload_trig_collider, playerCam, targetCam, blackOutScreen;
    public string sceneName;
    public bool sceneIsReady, interactable, timeWaited;
    public float timeToWait;
    public float timeCount = 0.0f;
    public float speed;
    public SC_FPSController playerController;

    private Collider boxCollider;
    private Vector3 playCamPos, playCamRot, rotateValue;


    


    void Start()
    {
        playCamPos = playerCam.transform.position;
        sceneIsReady = false;
        StartCoroutine(prepareNextLoop());
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
                
                playerController.enabled = false;
                Transform playerCamTrans = playerCam.GetComponent<Transform>();
                Transform targetCamTrans = targetCam.GetComponent<Transform>();

                playerCam.transform.rotation = Quaternion.Lerp(playerCamTrans.rotation, targetCamTrans.rotation, timeCount * speed);
                playerCam.transform.position = Vector3.Lerp(playerCamTrans.position, targetCamTrans.position, timeCount * speed);
                timeCount = timeCount + Time.deltaTime;
                    if(Vector3.Distance(playerCamTrans.position, targetCamTrans.position) < 0.01f){
                        if( Quaternion.Angle(playerCamTrans.rotation,targetCamTrans.rotation) < 0.01f){
                            blackOutScreen.SetActive(true);
                            StartCoroutine(waitAndLoadScene());
                            if(timeWaited == true)
                                {
                                asyncLoad.allowSceneActivation = true;
                                }
                        }

                    }
                
            }
        }
        
    }

    IEnumerator waitAndLoadScene()
    {
    yield return new WaitForSeconds(timeToWait);
    timeWaited = true;
    }

}


