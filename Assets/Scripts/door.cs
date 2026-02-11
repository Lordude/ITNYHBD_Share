using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject intText, unlockedText, key, lockedText;
    public bool interactable, toggle, triggerLoop;
    public Animator doorAnim;
    public int timeToTextFade;
    public GameObject triggerToCreate;
    public bool can_activate_trigger, first_time_unlocked;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(key.activeSelf == false)
                {
                toggle = !toggle;
                if(toggle == true)
                {   
                    if(first_time_unlocked = true)
                    {
                        triggerLoop = true;
                        unlockedText.SetActive(true);
                        first_time_unlocked = false;
                        StopCoroutine("disableText");
                        StartCoroutine("disableText");
                    }
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open");
                    
                    if(can_activate_trigger == true)
                    {
                        triggerToCreate.SetActive(true);
                    }
                }
                if(toggle == false)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close");
                }
                intText.SetActive(false);
                interactable = false;
                }
                if(key.activeSelf == true)
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
