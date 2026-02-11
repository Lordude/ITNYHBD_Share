using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camBob : MonoBehaviour
{

    public bool walking;
    //bleep lol test commit mac

    void Update() 
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walking = true;
        }
}
}
