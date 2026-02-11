using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitch : MonoBehaviour
{
    public GameObject inticon, lightOn, lightOff, light;
    public bool toggle = true, interactable;
    // public Renderer lightBulb;
    // public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;

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
            if(Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                lightSwitchSound.Play();
                // switchAnim.ResetTrigger("press");
                // switchAnim.SetTrigger("press");
            }

        }
        if(toggle == false)
        {
            // lightOff.SetActive(true);
            // lightOn.SetActive(false); 
            light.SetActive(false);
        }
        if(toggle == true)
        {
            // lightOff.SetActive(false);
            // lightOn.SetActive(true); 
            light.SetActive(true);
        }
    }
}
