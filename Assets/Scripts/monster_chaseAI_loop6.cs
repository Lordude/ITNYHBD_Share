using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class monster_chaseAI_loop6 : MonoBehaviour
{
    public GameObject playerCam, targetCam, blackScreen, sfx_monster;
    public NavMeshAgent ai;
    public Transform player;
    public SC_FPSController playerController;
    public Animator monsterAnim;
    public bool isMoving;
    public float timeCount = 0.0f;
    public float speed = 0.1f;
    Vector3 dest;

    void Start()
    {
        isMoving = true;
    }

    void Update()
    {
    if(isMoving)
        {
            monsterAnim.ResetTrigger("moving");
            monsterAnim.ResetTrigger("battle");
            monsterAnim.SetInteger("battle", 0);
            monsterAnim.SetInteger("moving", 1);
            dest = player.position;
            ai.destination = dest;
        }
    if(!isMoving)
        {
            deathGrab();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isMoving = false;
        }
    }

    void deathGrab()
    {
        playerController.enabled = false;
        monsterAnim.ResetTrigger("moving");
        monsterAnim.ResetTrigger("battle");
        monsterAnim.SetInteger("moving", 0);
        monsterAnim.SetInteger("battle", 2);
        Transform playerCamTrans = playerCam.GetComponent<Transform>();
        Transform targetCamTrans = targetCam.GetComponent<Transform>();

        playerCam.transform.rotation = Quaternion.Lerp(playerCamTrans.rotation, targetCamTrans.rotation, timeCount * speed);
        playerCam.transform.position = Vector3.Lerp(playerCamTrans.position, targetCamTrans.position, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;

            if(Vector3.Distance(playerCamTrans.position, targetCamTrans.position) < 0.01f)
            {
                if( Quaternion.Angle(playerCamTrans.rotation,targetCamTrans.rotation) < 0.01f){
                    sfx_monster.SetActive(true);
                    monsterAnim.SetInteger("moving", 4);
                    if(timeCount >= 3.3)
                    {
                        blackScreen.SetActive(true);
                        SceneManager.LoadScene("deathScene");
                    }
                }
            }
    }
}
