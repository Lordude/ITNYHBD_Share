using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorToLoop : MonoBehaviour
{
    public GameObject intIcon, unlockedText, key, lockedText, loop_trigger_box, activeThreat;
    public bool interactable, toggle, keyState, hasActiveThreat;
    public Animator doorAnim;
    public int timeToTextFade;
    public bool can_activate_trigger, first_time_unlocked, readyToLoop;


    void Start(){
        readyToLoop = false;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = true;
            intIcon.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            interactable = false;
            intIcon.SetActive(false);
        }
    }

    void Update()
    {
        if(!key.activeSelf){
            keyState = true;
        }
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(key.active == false)
                {
                readyToLoop = true;
                if(hasActiveThreat)
                {
                    activeThreat.SetActive(false);
                }
                }
                if(key.activeSelf)
                {
                    lockedText.SetActive(true);
                    doorAnim.ResetTrigger("open");
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("locked");
                    StopCoroutine("disableText");
                    StartCoroutine("disableText");
                }
            }
        }
    }
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(timeToTextFade);
        lockedText.SetActive(false);
        unlockedText.SetActive(false);
    }


}
