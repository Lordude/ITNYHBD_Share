using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loop13_deathBox : MonoBehaviour
{
    public string animTrigger;
    public Animator monsterAnim;
    public SC_FPSController playerController;
    public Camera playerCam;
    public AudioSource staticNoise, deathHitNoise;
    public GameObject monsterFloor, monsterDeathModel, blackScreen, secretVision;
    public int cutsceneTime;


        void Start()
        {
            Debug.Log("collider triggered");
            playerController.enabled = false;
            // monsterFloor.SetActive(false);
            monsterDeathModel.SetActive(true);
            secretVision.SetActive(true);
            monsterAnim.SetTrigger(animTrigger);
            staticNoise.Play(0);
            deathHitNoise.Play(0);
            playerCam.cullingMask |= 1 << LayerMask.NameToLayer("secretView"); 
            StartCoroutine(deathCutscene());
            
        }

        IEnumerator deathCutscene()
        {
            yield return new WaitForSeconds(cutsceneTime);
            blackScreen.SetActive(true);
            staticNoise.Pause();
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("deathScene");
        }

}
