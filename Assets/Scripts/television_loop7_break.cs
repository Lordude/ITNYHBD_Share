using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class television_loop7_break : MonoBehaviour
{

    public MeshDestroy mesh_destroy;
    public GameObject hammerExists, breakable_window_obj, inticon;
    public bool interactActive, interactable;


    void Start()
    {
        mesh_destroy = breakable_window_obj.GetComponent<MeshDestroy>();
    }


    void Update()
    {
        // if(!hammerExists.activeSelf)
        // {
            if(interactable == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inticon.SetActive(false);
                    interactable = false;
                    mesh_destroy.DestroyMesh();
                }
            }
        // }
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

}
