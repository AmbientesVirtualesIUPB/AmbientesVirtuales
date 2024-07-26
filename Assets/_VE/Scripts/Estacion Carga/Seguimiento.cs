using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public Transform carTransform; // El transform del veh�culo
    [Range(1, 10)]
    public float followSpeed = 2;
    [Range(1, 10)]
    public float lookSpeed = 5;

    private Vector3 offset; // La posici�n relativa de la c�mara respecto al veh�culo

    void Start()
    {
        // Calcula la posici�n inicial relativa de la c�mara respecto al veh�culo
        offset = transform.position - carTransform.position;
    }

    void FixedUpdate()
    {
        // Ajustar la posici�n de la c�mara para que siga al veh�culo
        Vector3 targetPosition = carTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Hacer que la c�mara mire hacia el veh�culo
        Vector3 lookDirection = carTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }
}
