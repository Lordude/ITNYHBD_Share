using System.Collections;
using System.Collections.Generic;
using UnityEngine;

     public class HandRotator : MonoBehaviour {
         private Vector3 v3Offset;
         private GameObject goFollow;
         private float speed = 0.5f;
     
         void Start () {
             goFollow = Camera.main.gameObject;
             v3Offset = transform.position - goFollow.transform.position;
         }
         
         void Update () {
             transform.position = goFollow.transform.position + v3Offset;
             transform.rotation  = Quaternion.Slerp (transform.rotation, goFollow.transform.rotation, speed * Time.deltaTime);
         }
     }
