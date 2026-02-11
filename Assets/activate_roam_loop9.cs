using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate_roam_loop9 : MonoBehaviour
{
    public loop9_navtest loop9_navtest;
    public GameObject trigbox;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            loop9_navtest.Roam();
            trigbox.SetActive(false);
        }
    }
}
