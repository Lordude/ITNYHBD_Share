using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableObject : MonoBehaviour
{
    public GameObject Obj;
    public float activeTime;
    public bool triggerbased;

    void FixedUpdate()
    {
        if(triggerbased == false)
        {
            if(Obj.active == true)
            {
                StartCoroutine(Disableobj());
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            // Obj.SetActive(false);
            StartCoroutine(Disableobj());

            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator Disableobj()
    {
        yield return new WaitForSeconds(activeTime);
        Obj.SetActive(false);
    }

}
