using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event2 : MonoBehaviour
{
    public GameObject monster, key;
    public Animator monsterAnim;
    public float cutsceneTime;


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!key.active)
            {
                monster.SetActive(true);
                StartCoroutine(cutscene());
            }
        }
    }



    IEnumerator cutscene()
    {
        monsterAnim.ResetTrigger("activate");
        monsterAnim.SetTrigger("activate");
        yield return new WaitForSeconds(cutsceneTime);
        monster.SetActive(false);
    }
}
