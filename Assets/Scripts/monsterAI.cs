using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class monsterAI : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform monster;
    public Transform player;
    Vector3 destination;

    void Update() 
    {
        destination = player.position;
        ai.destination = destination;    

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ai.destination = monster.position;
        }
    }
    }
}
