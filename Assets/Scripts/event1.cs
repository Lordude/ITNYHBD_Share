using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event1 : MonoBehaviour
{
    public float timeToWait;
    public GameObject monster, triggerBox;
    public AudioSource sfxScaryHit;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            monster.SetActive(true);
            sfxScaryHit.Play();
            StartCoroutine(despawnMonster());
            
        }
    }

    IEnumerator despawnMonster()
    {
        yield return new WaitForSeconds(timeToWait);
        monster.SetActive(false);
        triggerBox.SetActive(false);
    }

}
