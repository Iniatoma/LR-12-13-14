using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform myTarget;
    void Update()
    {
        if(myTarget != null)
        {
            Vector3 tragPos = myTarget.position;
            tragPos.z = transform.position.z;
            transform.position = tragPos;
        }
        
       
        
    }
}
