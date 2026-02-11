using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class event1_visible : MonoBehaviour
{
    public Renderer messageRenderer;
    public GameObject eventSpawner;

    void OnBecameVisible()
    {
        eventSpawner.SetActive(true);
    }



}
