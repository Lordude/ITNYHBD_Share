using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathGrab : MonoBehaviour
{
    public Animator monsterAnim;

        void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            monsterAnim.SetInteger("moving", 4);
            Debug.Log("You dead!");
        }
    }
}
