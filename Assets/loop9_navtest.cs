using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loop9_navtest : MonoBehaviour
{
      public Transform transfGoal, transfTargetA, transfTargetB, transfMonster, player ;
      public bool isRoaming;
      public UnityEngine.AI.NavMeshAgent agent;
      public GameObject playerCam, targetCam, blackScreen, sfx_monster;
      public Animator monsterAnim;
      public SC_FPSController playerController;
      public float speed = 0.1f;
      public float timeCount = 0.0f;

      public void Start()
      {
         isRoaming = true;
      }


      public void Update()
      {
         if(isRoaming == false)
         {
            deathGrab();
         }
      }



       public void Roam () 
       {
         isRoaming = true;
         agent.destination = transfGoal.position; 
         monsterAnim.ResetTrigger("moving");
         monsterAnim.SetInteger("moving", 1);
       }


       void OnTriggerEnter(Collider other)
       {
            if(other.CompareTag("Monster_target"))
            {
               if(transfGoal == transfTargetA)
                  {
                     monsterAnim.ResetTrigger("moving");
                     monsterAnim.SetInteger("moving", 0);
                     transfGoal = transfTargetB;
                     StartCoroutine(WaitAndGo());
                  }
               
            }
            if(other.CompareTag("Monster_targetB"))
            {
               if(transfGoal == transfTargetB)
                  {
                     monsterAnim.ResetTrigger("moving");
                     monsterAnim.SetInteger("moving", 0);
                     transfGoal = transfTargetA;
                     StartCoroutine(WaitAndGo());
                  }
            }
            if(other.CompareTag("Player"))
            {
               agent.Stop();
               isRoaming = false;
            }
      }

      void deathGrab()
      {
         playerController.enabled = false;
         monsterAnim.ResetTrigger("moving");
         monsterAnim.ResetTrigger("battle");
         monsterAnim.SetInteger("moving", 4);
         monsterAnim.SetInteger("battle", 1);
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
                     if(timeCount >= 1.2)
                     {
                           blackScreen.SetActive(true);
                           SceneManager.LoadScene("deathScene");
                     }
                  }
               }
      }

      IEnumerator WaitAndGo()
      {
         yield return new WaitForSeconds(3);
         agent.destination = transfGoal.position; 
         monsterAnim.ResetTrigger("moving");
         monsterAnim.SetInteger("moving", 1);
      }
}
