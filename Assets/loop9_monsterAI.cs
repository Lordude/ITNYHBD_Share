using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loop9_monsterAI : MonoBehaviour
{
    public Transform currentTargetPos, targetAPos, targetBPos, playerPos, monsterPos;
    public int currentTargetInt, pastTargetInt, intA, intB;
    public bool isMoving, isHiding, isChasing;
    public float patrolSpeed, chaseSpeed;
    public Animator monsterAnim;
    public Camera monsterCam;
    Vector3 dest;

    private UnityEngine.AI.NavMeshAgent ai;

    void Start()
    {
        UnityEngine.AI.NavMeshAgent ai = GetComponent<UnityEngine.AI.NavMeshAgent>();
        ai.destination = targetBPos.position;
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if(other.CompareTag("Monster_target"))
    //     {
    //         isMoving = false;
    //         monsterAnim.ResetTrigger("moving");
    //         monsterAnim.SetInteger("moving", 0);
    //         StartCoroutine(waitAndChooseTarget());
    //         Debug.Log(currentTargetInt);
    //     }
    // }

    void generateNewTarget()
    {
            if(currentTargetInt == intA)
            {
                currentTargetPos = targetBPos;
                ai.destination = currentTargetPos.position;
                currentTargetInt = intB;
            }
            if(currentTargetInt == intB)
            {
                currentTargetPos = targetAPos;
                ai.destination = currentTargetPos.position;
                currentTargetInt = intA;
            }

            // Collider targetCollider = currentTargetPos.GetComponent<Collider>();
            // targetCollider.enabled = true;


    }

    IEnumerator waitAndChooseTarget()
    {
        yield return new WaitForSeconds(3);
        Collider targetCollider = currentTargetPos.GetComponent<Collider>();
        // targetCollider.enabled = false;
        generateNewTarget();
        monsterAnim.ResetTrigger("moving");
        monsterAnim.SetInteger("moving", 1);
        isMoving = true;
    }
}
