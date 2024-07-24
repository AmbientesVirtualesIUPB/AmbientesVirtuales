using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BrazoGiratorio : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float rotationSpeed = 100f;
    private bool rotateRight = false;
    private bool rotateLeft = false;


    // Update se llama una vez por frame
    void Update()
    {
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
        rotateRight = true; 
        rotateLeft = false;
    }

    /// <summary>
    /// Métodos para iniciar y detener la rotación desde ButtonIzquierda en la scena
    /// </summary>
    /// <param name="data"></param>
    public void RotarIzquierdaPresionada(BaseEventData data)
    {
        rotateRight = false;
        rotateLeft = true;
    }

    /// <summary>
    /// Metodo invocado al dejar de presionar los botones del canvas
    /// </summary>
    /// <param name="data"></param>
    public void NoRotar(BaseEventData data)
    {
        rotateRight = false;
        rotateLeft = false;
    }

    /// <summary>
    /// Metodo invocado desde el script InicializarFurtivo, para detener movimientos
    /// </summary>
    public void Detener()
    {
        transform.rotation = Quaternion.identity;
    }
}
