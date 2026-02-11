using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target, source;
    public GameObject loopDoor;
    public doorToLoop doorToLoop; 
    public bool isCustomOffset;
    public Vector3 offset;
    private float timeCount = 0.0f;

    public float smoothSpeed = 0.1f;

    private void Start()
    {
        // You can also specify your own offset from inspector
        // by making isCustomOffset bool to true

        doorToLoop = loopDoor.GetComponent<doorToLoop>();
    }

    private void Update()
    {
        SmoothFollow();
    }

    public void SmoothFollow()
    {
        if(doorToLoop.readyToLoop)
        {
        // Vector3 targetPos = target.position + offset;
        // Vector3 smoothFollow = Vector3.Lerp(transform.position,
        // targetPos, smoothSpeed);
        // transform.position = smoothFollow;
        // transform.LookAt(target);
        transform.rotation = Quaternion.Slerp(source.rotation, target.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
        }    

    }
}
