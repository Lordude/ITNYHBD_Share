using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loop9_doorSwitch : MonoBehaviour
{
    public GameObject toCreateObjA, toCreateObjB, trigBox, toDestroyObj;
    public door_loop9 doorObj;
    public bool doorObjIsOpen;
    public Animator doorAnim;
    public string animTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            toCreateObjA.SetActive(true);
            toCreateObjB.SetActive(true);
            toDestroyObj.SetActive(false);
            doorAnim.SetTrigger(animTrigger);
            doorObj.isOpen = false;
        }
    }
}
