using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class loop8_monster_ai : MonoBehaviour
{
    public Transform currentTargetPos, posBedroom, posOffice, posLivingroom, posKitchen, posLaundryroom, posBasement, posDiningroom, playerPos, monsterPos;
    public int currentTargetInt, pastTargetInt, intBedroom, intOffice, intLivingroom, intKitchen, intLaundryroom, intBasement, intDiningroom;
    public bool isMoving, isHiding, isChasing;
    public float patrolSpeed, chaseSpeed;
    public Animator monsterAnim;
    public NavMeshAgent ai;
    public Camera monsterCam;
    Vector3 dest;

    void Start()
    {
        generateNewTarget();
        isHiding = true;
        isChasing = false;
        monsterAnim.SetTrigger("isChasing");

    }

    void Update()
    {
        if(isHiding)
        {        
            dest = currentTargetPos.position;
            ai.destination = dest;
        }
        if(isChasing)
        {
            dest = playerPos.position;
            ai.destination = dest;
        }
    }

    void StartChase()
    {
        isHiding = false;
        isChasing = true;
        monsterAnim.SetTrigger("isChasing");
        monsterAnim.speed = 0.7f;
        ai.speed = chaseSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster_target"))
        {
            isMoving = false;
            isHiding = false;
            monsterAnim.ResetTrigger("moving");
            monsterAnim.SetInteger("moving", 0);
            // monsterAnim.SetBool("isCrawling", false);
            StartCoroutine(waitAndChooseTarget());
            Debug.Log(currentTargetInt);
        }
        if(other.CompareTag("Player"))
        {
            generateNewTarget();
        }
    }

    void generateNewTarget()
    {
            if(currentTargetInt == intBedroom)
            {
                currentTargetPos = posBedroom;
            }
            if(currentTargetInt == intOffice)
            {
                currentTargetPos = posOffice;
            }
            if(currentTargetInt == intLivingroom)
            {
                currentTargetPos = posLivingroom;
            }
            if(currentTargetInt == intKitchen)
            {
                currentTargetPos = posKitchen;
            }
            if(currentTargetInt == intLaundryroom)
            {
                currentTargetPos = posLaundryroom;
            }
            if(currentTargetInt == intBasement)
            {
                currentTargetPos = posBasement;
            }
            if(currentTargetInt == intDiningroom)
            {
                currentTargetPos = posDiningroom;
            }
            Collider targetCollider = currentTargetPos.GetComponent<Collider>();
            targetCollider.enabled = true;
    }

    IEnumerator waitAndChooseTarget()
    {
        yield return new WaitForSeconds(3);
        Collider targetCollider = currentTargetPos.GetComponent<Collider>();
        targetCollider.enabled = false;
        generateNewTarget();
        monsterAnim.ResetTrigger("moving");
        monsterAnim.SetInteger("moving", 1);
        isHiding = true;
        isMoving = true;
    }
}
