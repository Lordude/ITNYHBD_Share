using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticShake : MonoBehaviour
{
    public GameObject staticTrans, refTrans;
    private float minXtrans, maxXtrans, minZtrans, maxZtrans, currentXtrans, currentZtrans;

    void Update()
    {
        staticTrans.transform.position = refTrans.transform.position;
        currentXtrans = Random.Range(-0.19f, 0.19f);
        currentZtrans = Random.Range(-0.19f, 0.19f);
        staticTrans.transform.Translate(currentXtrans, 0, currentZtrans);
        
    }
}
