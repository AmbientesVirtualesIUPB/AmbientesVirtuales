using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejemplo : MonoBehaviour
{
    void Start()
    {
        // Recorrer todos los hijos del objeto actual
        foreach (Transform child in transform)
        {
            // Verificar si el nombre del hijo empieza con un patrón específico
            if (child.gameObject.name.StartsWith("cro")) // Cambia "ABC" por las tres primeras letras del nombre que buscas
            {
                // Activar el objeto hijo que cumple la condición
                child.gameObject.SetActive(true);
            }
            else
            {
                // Desactivar los otros objetos hijos que no cumplen la condición (opcional)
                child.gameObject.SetActive(false);
            }
        }
    }
}
