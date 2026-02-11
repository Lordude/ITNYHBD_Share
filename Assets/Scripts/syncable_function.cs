using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncable_function : MonoBehaviour
{
    public GameObject gameObject1, gameObject2, gameObject3;
    public bool posSync, negSync;
    void Update()
    {
        if(negSync)
        {
            if(!gameObject1.activeSelf)
            {
                gameObject2.SetActive(false);
            }
        }
        
    }
}
