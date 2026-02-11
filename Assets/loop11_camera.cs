using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loop11_camera : MonoBehaviour
{
    public GameObject inticon, cam_film, message_noFilm, message_hasFilm, message_camUse, picture, cam, objectToCreate, sfx_cam;
    public bool interactable, createObject, need_film;
    public float timeToWait;
    public Animator anim1, anim2;
    public string animTrigger1, animTrigger2;
    public BoxCollider camCollider;


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
                if(!need_film)
                {
                    if(createObject)
                    {
                    objectToCreate.SetActive(true);
                    sfx_cam.SetActive(true);
                    }
                    camCollider.enabled = false;
                    message_camUse.SetActive(true);
                    anim1.SetTrigger(animTrigger1);
                    picture.SetActive(true);
                    anim2.SetTrigger(animTrigger2);
                }
                if(need_film)
                {
                    if(!cam_film.activeSelf)
                    {
                    if(createObject)
                    {
                    objectToCreate.SetActive(true);
                    sfx_cam.SetActive(true);
                    }
                    camCollider.enabled = false;
                    message_hasFilm.SetActive(true);
                    anim1.SetTrigger(animTrigger1);
                    picture.SetActive(true);
                    anim2.SetTrigger(animTrigger2);
                    }
                    if(cam_film.activeSelf)
                    {
                        message_noFilm.SetActive(true);
                    }
                }

                inticon.SetActive(false);
                interactable = false;
                StartCoroutine(closeMessage());
            }
        }
    }

    IEnumerator closeMessage()
    {
        yield return new WaitForSeconds(timeToWait);
        message_camUse.SetActive(false);
        message_noFilm.SetActive(false);
        message_hasFilm.SetActive(false);
    }
}
