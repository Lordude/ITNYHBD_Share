using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEventController : MonoBehaviour
{
    public bool hasObject1, hasObject2, hasAudio, hasAnim1, hasAnim2, hasTriggerBox, hasInteractable, hasVfxCam, hasDestroy1, hasDestroy2, hasTimer;
    public GameObject eventObject1, eventObject2, triggerBox, vfxCam, toDestroy1, toDestroy2, inticon;
    public AudioSource eventAudio;
    public Animator anim1, anim2;
    public string animTrigger1, animTrigger2;
    public float timeToWait;
    private bool toggle, interactable;
    

    void Start()
    {
        if(hasTriggerBox == false && hasTimer == false && hasInteractable == false)
        {
            activateBools();
        }
        if(hasTimer == true && hasInteractable == false)
        {
            StartCoroutine(waitAndActivate());
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(hasTriggerBox)
            {
                if(hasTimer == false)
                {
                activateBools();
                triggerBox.SetActive(false);
                }
                else if(hasTimer){
                    StartCoroutine(waitAndActivate());
                }
            }
        }
        if(other.CompareTag("MainCamera"))
        {
            if(hasInteractable)
            {
                if(toggle == false)
                {
                inticon.SetActive(true);
                interactable = true;
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(hasInteractable){
        if (other.CompareTag("MainCamera"))
            {
                inticon.SetActive(false);
                interactable = false;
            }
        }
    }

    void Update() 
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                inticon.SetActive(false);
                interactable = false;
                activateBools();
            }
        }    
    }

    void activateBools()
    {
        if(hasObject1 == true)
        {
            eventObject1.SetActive(true);
        }
        if(hasObject2 == true)
        {
            eventObject2.SetActive(true);
        }
        if(hasAudio == true)
        {
            eventAudio.Play();
        }
        if(hasAnim1 == true)
        {
            anim1.SetTrigger(animTrigger1);
        }
        if(hasAnim2 == true)
        {
            anim2.SetTrigger(animTrigger2);
        }
        if(hasVfxCam == true)
        {
            vfxCam.SetActive(true);
        }
        if(hasDestroy1 == true)
        {
            toDestroy1.SetActive(false);
        }
        if(hasDestroy2 == true)
        {
            toDestroy2.SetActive(false);
        }
    }
    
    IEnumerator waitAndActivate()
    {
    yield return new WaitForSeconds(timeToWait);
    activateBools();
    if(hasTriggerBox){
    triggerBox.SetActive(false);
    }
    }

}
