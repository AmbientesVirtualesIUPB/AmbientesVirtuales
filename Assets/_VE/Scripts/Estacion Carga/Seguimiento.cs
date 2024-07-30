using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguimiento : MonoBehaviour
{
    public Transform target; // El veh�culo al que la c�mara seguir�
    public float followDistance = 3f; // Distancia de la c�mara al objetivo
    public float height = 1.5f; // Altura de la c�mara respecto al objetivo
    public float rotationSpeed; // Velocidad de rotaci�n de la c�mara
    public float maxDepth = 20f; // Distancia m�xima permitida en el eje Z

    private Vector3 offset; // Offset inicial de la c�mara

    private void Start()
    {
        // Calcula el offset inicial de la c�mara en relaci�n al veh�culo
        offset = new Vector3(0, height, -followDistance);
    }

    private void FixedUpdate()
    {
        if (target == null)
            return;

        // Calcula la posici�n deseada de la c�mara
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Calcula la distancia en el eje Z entre la c�mara y el objetivo
        float distanceZ = Mathf.Abs(target.position.z - desiredPosition.z);

        // Limita la distancia m�xima en el eje Z
        if (distanceZ > maxDepth)
        {
            desiredPosition.z = target.position.z + Mathf.Sign(desiredPosition.z - target.position.z) * maxDepth;
        }

        // Interpola suavemente la posici�n de la c�mara
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * rotationSpeed);

        // Calcula la rotaci�n objetivo de la c�mara basada en la rotaci�n del veh�culo
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);

        // Interpola suavemente la rotaci�n de la c�mara
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}

