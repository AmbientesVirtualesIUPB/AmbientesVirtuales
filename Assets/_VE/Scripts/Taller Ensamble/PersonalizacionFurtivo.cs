using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PersonalizacionFurtivo : MonoBehaviour
{
    public GameObject[] furtivos;
    public int activo;

    /// <summary>
    /// Metodo invocado desde ButtonCambiarVehiculo en el canvas
    /// </summary>
    public void Siguiente()
    {
        activo = (activo + 1) % furtivos.Length;
        
        for (int i = 0; i < furtivos.Length; i++)
        {
            furtivos[i].SetActive(i == activo);
        }
        
    }
}
