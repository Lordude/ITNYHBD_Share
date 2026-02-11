using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loop7_deathBox : MonoBehaviour
{
    public int timerValue;
    public int timerMax = 700;

    public string animTrigger;
    public Animator monsterAnim;
    public SC_FPSController playerController;
    public Camera playerCam, targetCam;
    public GameObject monsterDeathModel, blackScreen, playerCamObj, targetCamObj, staticNoise, deathHitNoise;
    public float cutsceneTime;
    public float timeCount, speed;


    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            timerValue = 0;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(timerValue == timerMax)
            {
                killPlayer();
            }
            timerValue += 1;
        }
    }

    void killPlayer()
    {
        playerController.enabled = false;
        Transform playerCamTrans = playerCam.GetComponent<Transform>();
        Transform targetCamTrans = targetCam.GetComponent<Transform>();
        monsterDeathModel.SetActive(true);


        playerCam.transform.rotation = Quaternion.Lerp(playerCamTrans.rotation, targetCamTrans.rotation, timeCount * speed);
        staticNoise.SetActive(true);
        deathHitNoise.SetActive(true);
        playerCam.transform.position = Vector3.Lerp(playerCamTrans.position, targetCamTrans.position, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;
            if(Vector3.Distance(playerCamTrans.position, targetCamTrans.position) < 0.01f){
                if( Quaternion.Angle(playerCamTrans.rotation,targetCamTrans.rotation) < 0.01f){
                    playerCamObj.SetActive(false);
                    targetCamObj.SetActive(true);

                    monsterDeathModel.SetActive(true);
                    monsterAnim.SetTrigger(animTrigger);

                    StartCoroutine(deathCutscene());
                }
            }
    }


    IEnumerator deathCutscene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        blackScreen.SetActive(true);
        staticNoise.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("deathScene");
    }

}
