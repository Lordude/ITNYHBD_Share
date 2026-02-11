using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaryEventTrigger2 : MonoBehaviour
{
    public GameObject scare;
    public AudioSource scareSound;
    public Collider collision;
    public Animator flashlight;
    public Animator lightbulb;
    public float timeToWait;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            lightbulb.SetTrigger("scaryEvent2");
            flashlight.SetTrigger("scaryEvent2");
            //scareSound.Play();
            scare.SetActive(true);
            collision.enabled = false;
            StartCoroutine(inactivateMonster());
        }
    }

    IEnumerator inactivateMonster()
    {
        yield return new WaitForSeconds(timeToWait);
        scare.SetActive(false);
    }


}
