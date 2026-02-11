using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_loop9 : MonoBehaviour
{
    public GameObject intText, unlockedText, key, lockedText;
    public bool interactable, isOpen, triggerLoop;
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
                isOpen = !isOpen;
                if(isOpen == true)
                {   
                    doorAnim.ResetTrigger("close");
                    doorAnim.SetTrigger("open");
                }
                if(isOpen == false)
                {
                    doorAnim.ResetTrigger("open");
                    doorAnim.SetTrigger("close");
                }
                intText.SetActive(false);
                interactable = false;
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
