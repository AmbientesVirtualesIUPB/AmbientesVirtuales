using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrazoGiratorio : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 10f;
    private bool rotateRight = false;
    private bool rotateLeft = false;
    public bool sinPresionar = false;


    // Update se llama una vez por frame
    void Update()
    {
        if (sinPresionar)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        if (rotateRight)
        {
            // Rotar hacia la derecha (sentido horario)
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        else if (rotateLeft)
        {
            // Rotar hacia la izquierda (sentido antihorario)
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
    }

    /// <summary>
    /// Métodos para iniciar y detener la rotación desde ButtonDerecha en la scena
    /// </summary>
    /// <param name="data"></param>
    public void RotarDerechaPresionada(BaseEventData data)
    {
        sinPresionar = false;
        rotateRight = true; 
        rotateLeft = false;
        rotationSpeed = 100f;
    }

    /// <summary>
    /// Métodos para iniciar y detener la rotación desde ButtonIzquierda en la scena
    /// </summary>
    /// <param name="data"></param>
    public void RotarIzquierdaPresionada(BaseEventData data)
    {
        sinPresionar = false;
        rotateRight = false;
        rotateLeft = true;
        rotationSpeed = 100f;
    }

    /// <summary>
    /// Metodo invocado al dejar de presionar los botones del canvas
    /// </summary>
    /// <param name="data"></param>
    public void NoRotar(BaseEventData data)
    {
        sinPresionar = true;
        rotateRight = false;
        rotateLeft = false;
        rotationSpeed = 10f;
    }

    public void Detener()
    {
        sinPresionar = false;
        transform.rotation = Quaternion.identity;
    }
}
