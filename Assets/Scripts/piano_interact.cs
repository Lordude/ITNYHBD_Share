using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piano_interact : MonoBehaviour
{

    public GameObject inticon, playerCam, playerCamOG, targetCam, pianoObj, pianoCam_Obj, exitHandler_obj, audio_lullaby, whiteBoardHandler, soundtrack, endDirectionMessage, postFXcamObj;
    public Transform player;
    public Animator pianoCam_anim, mainDoor_anim;
    public SC_FPSController playerController;
    public bool interactable, cutSceneOn, doubleVisionBool;
    public float timeCount = 0.0f;
    public float speed = 0.1f;

    private Collider boxCollider;

    void Start()
    {
        boxCollider = pianoObj.GetComponent<BoxCollider>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inticon.SetActive(false);
                interactable = false;
                cutSceneOn = true;
            }
        }
        if(cutSceneOn)
        {
            pianoCutscene();
        }

        if(timeCount > 0)
        {
            if(timeCount > 33)
            {
                reactivePlayer();
                endDirectionMessage.SetActive(true);
            }
        }

    }

    void pianoCutscene()
    {
        soundtrack.SetActive(false);
        whiteBoardHandler.SetActive(true);
        playerController.doubleVision = false;
        playerCamOG.SetActive(false);
        postFXcamObj.SetActive(false);
        playerCam.SetActive(true);
        boxCollider.enabled = false;
        playerController.enabled = false;

        Transform playerCamTrans = playerCam.GetComponent<Transform>();
        Transform targetCamTrans = targetCam.GetComponent<Transform>();

        playerCam.transform.rotation = Quaternion.Lerp(playerCamTrans.rotation, targetCamTrans.rotation, timeCount * speed);
        playerCam.transform.position = Vector3.Lerp(playerCamTrans.position, targetCamTrans.position, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;

            if(Vector3.Distance(playerCamTrans.position, targetCamTrans.position) < 0.01f)
            {
                if( Quaternion.Angle(playerCamTrans.rotation,targetCamTrans.rotation) < 0.01f){
                    //switch camera and start animation ? 
                    playerCam.SetActive(false);
                    targetCam.SetActive(true);
                    pianoCam_Obj.SetActive(true);
                    if(pianoCam_anim.gameObject.activeSelf){
                        pianoCam_anim.SetBool("cutscene", true);
                        audio_lullaby.SetActive(true);
                    }
                }
            }
    }

    void reactivePlayer()
    {
        Transform playerCamTrans = playerCamOG.GetComponent<Transform>();
        Transform targetCamTrans = targetCam.GetComponent<Transform>();

        targetCam.transform.rotation = Quaternion.Lerp(targetCamTrans.rotation, playerCamTrans.rotation, timeCount * speed);
        targetCam.transform.position = Vector3.Lerp(targetCamTrans.position, playerCamTrans.position, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;

            if(Vector3.Distance(targetCamTrans.position, playerCamTrans.position) < 0.01f)
            {
                if( Quaternion.Angle(targetCamTrans.rotation,playerCamTrans.rotation) < 0.01f){
                    targetCam.SetActive(false);
                    playerCamOG.SetActive(true);
                    playerController.enabled = true;
                    cutSceneOn = false;
                    pianoCam_Obj.SetActive(false);
                    pianoObj.SetActive(false);
                    exitHandler_obj.SetActive(true);
                    mainDoor_anim.SetTrigger("open");
                }
            }
    }

}
