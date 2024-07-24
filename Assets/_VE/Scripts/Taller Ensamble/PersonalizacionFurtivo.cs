using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PersonalizacionFurtivo : MonoBehaviour
{
    public GameObject   controlCamara;
    public GameObject[] furtivos; 
    public int[]        activo;


    public void SiguienteCarroceria(int id)
    {
        activo[0] = (activo[0] + 1) % furtivos.Length;
        StartCoroutine(controlCamara.gameObject.GetComponent<InicializarFurtivo>().CambiarCamara(1, id));

        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[0])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("cro")) // En este caso buscamos activar las carrocerias
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas las demas carrocerias
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("cro")) // En este caso buscamos activar las carrocerias
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }

    }


    public void SiguienteAleron(int id)
    {
        activo[1] = (activo[1] + 1) % furtivos.Length;
        StartCoroutine(controlCamara.gameObject.GetComponent<InicializarFurtivo>().CambiarCamara(1, id));

        bool encontrado = false; 

        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[1])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("ale")) // En este caso buscamos activar las carrocerias
                    {
                        encontrado = true;
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }

                    
                }
                if (encontrado == false)
                {
                    activo[1]++;
                }
            }
            else
            {
                // En caso contrario, desactivamos todas los demas alerones
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("ale")) // En este caso buscamos activar las carrocerias
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }

            

        }

    }


    public void SiguienteSilla(int id)
    {
        activo[2] = (activo[2] + 1) % furtivos.Length;
        StartCoroutine(controlCamara.gameObject.GetComponent<InicializarFurtivo>().CambiarCamara(2,id));

        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[2])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("sil")) // En este caso buscamos activar las carrocerias
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas las demas sillas
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("sil")) // En este caso buscamos activar las carrocerias
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }

        }

    }

    public void SiguienteVolante(int id)
    {
        activo[3] = (activo[3] + 1) % furtivos.Length;
        StartCoroutine(controlCamara.gameObject.GetComponent<InicializarFurtivo>().CambiarCamara(3,id));

        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[3])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("vol")) // En este caso buscamos activar las carrocerias
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas los demas volantes
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("vol")) // En este caso buscamos activar las carrocerias
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }

        }

    }

    public void SiguienteLlantas(int id)
    {
        activo[4] = (activo[4] + 1) % furtivos.Length;
        StartCoroutine(controlCamara.gameObject.GetComponent<InicializarFurtivo>().CambiarCamara(1, id));

        for (int i = 0; i < furtivos.Length; i++)
        {
            if (i == activo[4])
            {
                // Recorrer todos los hijos del objeto actual
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("whe")) // En este caso buscamos activar las carrocerias
                    {
                        // Activar el objeto hijo que cumple la condición
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                // En caso contrario, desactivamos todas las demas llantas
                foreach (Transform child in furtivos[i].transform)
                {
                    // Verificar si el nombre del hijo empieza con un patrón específico
                    if (child.gameObject.name.StartsWith("whe")) // En este caso buscamos activar las carrocerias
                    {
                        // Desactivamos el objeto hijo que cumple la condición
                        child.gameObject.SetActive(false);
                    }
                }
            }

        }

    }
}
