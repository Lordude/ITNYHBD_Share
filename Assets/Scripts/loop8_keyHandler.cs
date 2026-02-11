using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loop8_keyHandler : MonoBehaviour
{
    public GameObject doorKey1, doorKey2, doorKey3, doorKey4, doorKey5, anyKey1, anyKey2, anyKey3, anyKey4, anyKey5, loop_preload_trigger;
    public int keyCount;
    [SerializeField] List<GameObject> anyKeys;

    void Start()
    {
        anyKeys = new List<GameObject>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!anyKey1.activeSelf)
        {
            if(!anyKeys.Contains(anyKey1))
            {
                anyKeys.Add(anyKey1);
                checkKeysUnlock();
            }
        }
        if(!anyKey2.activeSelf)
        {
            if(!anyKeys.Contains(anyKey2))
            {
            anyKeys.Add(anyKey2);
            checkKeysUnlock();
            }
        }
        if(!anyKey3.activeSelf)
        {
            if(!anyKeys.Contains(anyKey3))
            {
            anyKeys.Add(anyKey3);
            checkKeysUnlock();
            }
        }
        if(!anyKey4.activeSelf)
        {
            if(!anyKeys.Contains(anyKey4))
            {
            anyKeys.Add(anyKey4);
            checkKeysUnlock();
            }
        }
        if(!anyKey5.activeSelf)
        {
            if(!anyKeys.Contains(anyKey5))
            {
            anyKeys.Add(anyKey5);
            checkKeysUnlock();
            }
        }
    }

    void checkKeysUnlock()
    {
        if(anyKeys.Count == 1)
        {
            doorKey1.SetActive(false);
        }
        if(anyKeys.Count == 2)
        {
            doorKey2.SetActive(false);
        }
        if(anyKeys.Count == 3)
        {
            doorKey3.SetActive(false);
        }
        if(anyKeys.Count == 4)
        {
            doorKey4.SetActive(false);
        }
        if(anyKeys.Count == 5)
        {
            doorKey5.SetActive(false);
            loop_preload_trigger.SetActive(true);
        }
    }
}
