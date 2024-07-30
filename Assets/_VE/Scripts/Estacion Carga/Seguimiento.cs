using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public Transform target; // El vehículo al que la cámara seguirá
    public float followDistance = 3f; // Distancia de la cámara al objetivo
    public float height = 1.5f; // Altura de la cámara respecto al objetivo
    public float rotationSpeed; // Velocidad de rotación de la cámara
    public float maxDepth = 20f; // Distancia máxima permitida en el eje Z

    private Vector3 offset; // Offset inicial de la cámara

    private void Start()
    {
        // Calcula el offset inicial de la cámara en relación al vehículo
        offset = new Vector3(0, height, -followDistance);
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Calcula la distancia en el eje Z entre la cámara y el objetivo
        float distanceZ = Mathf.Abs(target.position.z - desiredPosition.z);

        // Limita la distancia máxima en el eje Z
        if (distanceZ > maxDepth)
        {
            desiredPosition.z = target.position.z + Mathf.Sign(desiredPosition.z - target.position.z) * maxDepth;
        }

        // Interpola suavemente la posición de la cámara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);

        // Calcula la rotación objetivo de la cámara basada en la rotación del vehículo
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Interpola suavemente la rotación de la cámara
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}

