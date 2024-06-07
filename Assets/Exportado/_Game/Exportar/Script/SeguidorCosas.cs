using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorCosas : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.right * target.localPosition.x + Vector3.forward * target.localPosition.z;
        transform.localEulerAngles = Vector3.up * target.localEulerAngles.y;
    }
}
