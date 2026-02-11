using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class interactLaptop : MonoBehaviour
{
    public GameObject inticon, playerCam, targetCam, player, inputFieldObj, successEvent, uiLaptopQuitMessage, firstScreenCam, secondScreenCam, laptop_screen;
    // public InputField inputField;
    public bool interactable, inScreen;
    public float timeCount = 0.0f;

    public float timeToWait;
    public float speed = 0.1f;
    public SC_FPSController playerController;
    // public camBob camBob;

    [SerializeField] TextMeshProUGUI computer_message;

    // private string answer = "henry";

    private TextMeshProUGUI answer_validate_message;



    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(false);
            interactable = false;
        }
    }

    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inticon.SetActive(false);
                interactable = false;
                zoomInScreen();
            }
        }
        if(inScreen)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                exitScreen();
            }
            if(Input.GetKeyDown(KeyCode.Return))
            {
                loop3_adventureGame adventureGame = laptop_screen.GetComponent<loop3_adventureGame>();
                adventureGame.enabled = true;
            }
        }
    }

    void zoomInScreen()
    {
        playerController.enabled = false;
        playerCam.SetActive(false);
        targetCam.SetActive(true);
        inScreen = true;
        uiLaptopQuitMessage.SetActive(true);
    }

    void exitScreen()
    {        
        inScreen = false;
        uiLaptopQuitMessage.SetActive(false);
        playerController.enabled = true;
        targetCam.SetActive(false);
        playerCam.SetActive(true);
    }

    IEnumerator switchCameraScreen()
    {
        yield return new WaitForSeconds(timeToWait);
        firstScreenCam.SetActive(false);
        secondScreenCam.SetActive(true);

    }

}


