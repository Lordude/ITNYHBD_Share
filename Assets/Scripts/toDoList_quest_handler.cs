using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toDoList_quest_handler : MonoBehaviour
{
    public GameObject taskDone1, taskDone2, taskDone3, allTaskDoneParent;
    public bool hasCountedTask1, hasCountedTask2, hasCountedTask3;
    public int taskDoneCount;

    void Start()
    {
        hasCountedTask1 = false;
        hasCountedTask2 = false;
        hasCountedTask3 = false;
        taskDoneCount = 0;
    }

    void Update()
    {
        if(!hasCountedTask1){
            if(taskDone1.activeSelf == true)
            {
                checkTask1();
            }
        }
        if(!hasCountedTask2){
            if(taskDone2.activeSelf == true)
            {
                checkTask2();
            }
        }
        if(!hasCountedTask3){
            if(taskDone3.activeSelf == true)
            {
                checkTask3();
            }
        }
        if(taskDoneCount > 2)
        {
            allTaskDoneParent.SetActive(true);
        }
    }
    void checkTask1()
    {
        hasCountedTask1 = true;
        taskDoneCount += 1;
    }
    void checkTask2()
    {
        hasCountedTask2 = true;
        taskDoneCount += 1;
    }
    void checkTask3()
    {
        hasCountedTask3 = true;
        taskDoneCount += 1;
    }
}
