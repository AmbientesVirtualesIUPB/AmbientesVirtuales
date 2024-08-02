using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionObjeto : MonoBehaviour
{
    // Velocidad de rotación en grados por segundo
    public float velocidadRotacion = 50f;

    /// <summary>
    /// Metodo invocado frame a frame
    /// </summary>
    void Update()
    {
        // Rotar el objeto que tenga el script alrededor del eje Y
        transform.Rotate(0, velocidadRotacion * Time.deltaTime,0);
    }
}
