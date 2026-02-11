using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mugQuest_pickup : MonoBehaviour
{
    public GameObject mug, inticon;
    public bool interactable;
    public mug_quest_tracker mug_quest_track;

    private void Start()
    {
        mug_quest_track = mug_quest_track.GetComponent<mug_quest_tracker>();
    }

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
                mug.SetActive(false);
                mug_quest_track.mugCount += 1;
            }
        }
    }
}
