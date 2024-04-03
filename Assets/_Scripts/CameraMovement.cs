using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;

    public void SetTarget(GameObject targetObject)
    {
        target = targetObject;
    }
    void LateUpdate()
    {
        if(target != null)
        {
            transform.position = target.transform.position + offset;
        }
        
    }
}
