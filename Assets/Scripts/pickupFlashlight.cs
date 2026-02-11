using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupFlashlight : MonoBehaviour
{
    public GameObject inticon, flashlight_mesh, lens_mesh, flashlight_object, flashlight_hand, dialogue, somethingToTrigger;
    public float dialogueTime;
    public AudioSource pickup;
    public bool interactable, triggerSomething;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            if(dialogue.activeSelf == true)
            {
            inticon.SetActive(false);
            interactable = false;
            }
            if(dialogue.activeSelf == false)
            {
            inticon.SetActive(true);
            interactable = true;
            }
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
                pickup.Play();
                flashlight_hand.SetActive(true);
                flashlight_object.SetActive(false);
                dialogue.SetActive(true);
                if(triggerSomething)
                {
                    somethingToTrigger.SetActive(true);
                }
                // StartCoroutine(disableDialogue());
            }
        }
    }

    IEnumerator disableDialogue()
    {
        yield return new WaitForSeconds(dialogueTime);
        dialogue.SetActive(false);
    }
}
