using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorToLoop_loop5 : MonoBehaviour
{
    public GameObject intIcon, unlockedText, key_unprinted, key_printed, printer_trigbox, lockedText, loop_trigger_box, wrongKeyText;
    public bool interactable, toggle;
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
            intIcon.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(key_unprinted.active == false)
                {
                    if(printer_trigbox.active == false){
                        if(key_printed.active == false){
                            readyToLoop = true;
                        }
                    }
                    if(printer_trigbox.active == true){
                    wrongKeyText.SetActive(true);
                    doorAnim.ResetTrigger("open");
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("locked");

                    }
                // intIcon.SetActive(false);
                // interactable = false;
                }
                if(key_unprinted.active == true)
                {
                    lockedText.SetActive(true);
                    doorAnim.ResetTrigger("open");
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("locked");
                }
            StartCoroutine("disableText");
            }
        }
    }
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(timeToTextFade);
        wrongKeyText.SetActive(false);
        lockedText.SetActive(false);
        unlockedText.SetActive(false);
    }


}
