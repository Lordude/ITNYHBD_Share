using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loop_prep_loop5 : MonoBehaviour
{
    public GameObject preload_trig_collider, loopDoor, playerCam, targetCam;
    public string sceneName;
    public bool sceneIsReady, interactable;
    public doorToLoop_loop5 doorToLoop; 
    public float timeCount = 0.0f;
    public float speed = 0.1f;
    public SC_FPSController playerController;

    private Collider boxCollider;
    private Vector3 playCamPos, playCamRot, rotateValue;


    


    void Start()
    {
        playCamPos = playerCam.transform.position;
        sceneIsReady = false;
        boxCollider = preload_trig_collider.GetComponent<BoxCollider>();
        doorToLoop = loopDoor.GetComponent<doorToLoop_loop5>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StopCoroutine(prepareNextLoop());
            StartCoroutine(prepareNextLoop());
        }
    }

    IEnumerator prepareNextLoop()
    {
        boxCollider.enabled = false;
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

                playerCam.transform.rotation = Quaternion.Lerp(playerCamTrans.rotation, targetCamTrans.rotation, timeCount * speed);
                playerCam.transform.position = Vector3.Lerp(playerCamTrans.position, targetCamTrans.position, timeCount * speed);
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


// cam to go to : UnityEditor.TransformWorldPlacementJSON:{"position":{"x":-2.288997173309326,"y":1.624945044517517,"z":12.864060401916504},"rotation":{"x":0.3361769914627075,"y":-0.06944313645362854,"z":0.024864226579666139,"w":0.9389060735702515},"scale":{"x":1.0,"y":1.0,"z":1.0}}