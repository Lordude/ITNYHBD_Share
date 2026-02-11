using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Fallbox : MonoBehaviour
{

    public GameObject blackScreen;
    public SC_FPSController playerController;


    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        blackScreen.SetActive(true);
        playerController.enabled = false;
        SceneManager.LoadScene("deathScene");
    }
}
