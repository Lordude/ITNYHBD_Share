using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupKey : MonoBehaviour
{
    public GameObject inticon, key, somethingToTrigger;
    // public Animator doorToClose;
    // public AudioSource pickupsound;
    public bool interactable, triggerSomething;

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
                key.SetActive(false);
                if(triggerSomething == true)
                {
                    somethingToTrigger.SetActive(true);
                }
            }
        }
    }
}
