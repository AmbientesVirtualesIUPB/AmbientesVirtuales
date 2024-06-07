using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// El propósito de esta clase es que las turbinas miren hacia las manos
/// básicamente hace un LookAt on una rotación en desface 
/// </summary>
public class RotadorMirador : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Update()
    {
        transform.LookAt(target);
        transform.Rotate(offset);
    }
}
