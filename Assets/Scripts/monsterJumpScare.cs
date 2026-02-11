using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monsterJumpScare : MonoBehaviour
{
    public Animator monsterAnim;
    public GameObject player;
    public float jumpscareTime;
    public string sceneName;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            player.SetActive(false);
            monsterAnim.SetTrigger("jumpScare");
            StartCoroutine(jumpscare());
        }

        IEnumerator jumpscare()
        {
            yield return new WaitForSeconds(jumpscareTime);
            SceneManager.LoadScene(sceneName);
        }
    }
}
