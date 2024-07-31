using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamaras : MonoBehaviour
{
    public GameObject[] camaras; // Camaras entre las que queremos cambiar vistas
    private int         activo; // Para activar una a una las camaras

    // Update is called once per frame
    void Update()
    {
        // Verificar si se presiona la tecla C
        if (Input.GetKeyDown(KeyCode.C))
        {
            CambiarCamara();
        }
    }

    /// <summary>
    /// Metodo para cambiar entre camara tercera persona, panoramica y primera persona
    /// </summary>
    public void CambiarCamara()
    {
        // Asignamos a activo un valor dependiendo del punto del array camaras donde estemos
        activo = (activo + 1) % camaras.Length;

        // Recorremos una a una las camaras
        for (int i = 0; i < camaras.Length; i++)
        {
            // A la siguiente camara en la lista
            if (activo == i)
            {
                // Le damos prioridad 1 para que se renderice sobre las demas
                camaras[i].gameObject.GetComponent<Camera>().depth = 1;
            }
            else
            {
                // A las demas camaras le dejamos la prioridad en cero
                camaras[i].gameObject.GetComponent<Camera>().depth = 0;
            }
        }
    }
}
