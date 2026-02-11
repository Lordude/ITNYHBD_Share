using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mug_quest_tracker : MonoBehaviour
{
    public GameObject mug1_message, mug2_message, mug3_message, allMugs_message, kitchen_mugQuest_Parent;
    private bool mug1Accounted, mug2Accounted, mug3Accounted, allMugsAccounted;
    public int mugCount;
    // Update is called once per frame
    void Update()
    {
        if(!mug1Accounted)
        {
            if(mugCount == 1)
            {
                mug1Accounted = true;
                mug1_message.SetActive(true);
            }
        }
        if(!mug2Accounted)
        {
            if(mugCount == 2)
            {
                mug2Accounted = true;
                mug2_message.SetActive(true);
            }
        }
        if(!mug3Accounted)
        {
            if(mugCount == 3)
            {
                mug3Accounted = true;
                mug3_message.SetActive(true);
            }
        }

        if(!allMugsAccounted)
        {
            if(mugCount == 4)
            {
                allMugsAccounted = true;
                allMugs_message.SetActive(true);
                kitchen_mugQuest_Parent.SetActive(true);
            }
        }
    }
}
