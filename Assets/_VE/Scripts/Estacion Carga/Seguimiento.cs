using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public Transform carTransform; // El transform del vehículo
    [Range(1, 10)]
    public float followSpeed = 2;
    [Range(1, 10)]
    public float lookSpeed = 5;

    private Vector3 offset; // La posición relativa de la cámara respecto al vehículo

    void Start()
    {
        // Calcula la posición inicial relativa de la cámara respecto al vehículo
        offset = transform.position - carTransform.position;
    }

    void FixedUpdate()
    {
        // Ajustar la posición de la cámara para que siga al vehículo
        Vector3 targetPosition = carTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Hacer que la cámara mire hacia el vehículo
        Vector3 lookDirection = carTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }
}
