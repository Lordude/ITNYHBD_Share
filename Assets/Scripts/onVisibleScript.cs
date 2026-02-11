using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onVisibleScript : MonoBehaviour
{
    public GameObject objectToSee, player;
    private bool isSeen, isNotSeen;


    void OnBecameVisible() {
        isSeen = true;
        Debug.Log("In FOV");
    }

    void OnBecameInvisible() {
        isSeen = false;
        Debug.Log("Out FOV");
    }

    void FixedUpdate()
    {
        if(isSeen == true)
        {
        //casting rays towards the player. if the ray hits the player, the cover is not valid anymore.
        //LookAtPlayer(); //first we need to look at him/her to have a chance hitting him/her
        RaycastHit checkCover;
        // create the ray to use
        Ray ray = new Ray(transform.position, player.transform.position - transform.position);
        //casting a ray against the player
        if (Physics.Raycast(ray, out checkCover, 10f))
        {
            //we are here if the ray hit a collider
            //now to check if that collider is the player
            if (checkCover.collider.gameObject.CompareTag("Player") || checkCover.collider.gameObject.CompareTag("MainCamera"))
            {
                Debug.Log("Raycast hit and visible");
            }
        }
        }
    }

}
