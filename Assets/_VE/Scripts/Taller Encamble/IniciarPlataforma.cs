using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class IniciarPlataforma : MonoBehaviour
{
    public GameObject brazo; // El objeto a desplazar
    public GameObject plataforma; // Referencia a las puertas de la plataforma para utilizar su componenete animator
    public Transform[] posiciones; // El objeto al que quieres moverte
    public float tiempoSuavizado = 0.3f; // Tiempo de suavizado
    private Vector3 velocidad = Vector3.zero; // Vector de velocidad


    /// <summary>
    /// Funcion para iniciar la currutina del movimiento suave hacia arriba
    /// </summary>
    [ContextMenu("arriba")]
    public void MoverArriba()
    {
        StopAllCoroutines();
        StartCoroutine(MovimientoSuave(0));
    }

    /// <summary>
    /// Funcion para iniciar la currutina del movimiento suave hacia abajo
    /// </summary>
    [ContextMenu("abajo")]
    public void MoverAbajo()
    {
        StopAllCoroutines();
        StartCoroutine(MovimientoSuave(1));
    }


    /// <summary>
    /// Currutina para iniciar el movimiento suave
    /// </summary>
    /// <param name="posicion"> Indica a que posicon nos vamos a mover</param>
    /// <returns></returns>
    IEnumerator MovimientoSuave(int posicion)
    {
        // Validamos si se esta abriendo la compuerta
        if (posicion == 0)
        {   
            // Activamos la animaci�n deseada
            plataforma.gameObject.GetComponent<Animator>().SetBool("open", true);
            plataforma.gameObject.GetComponent<Animator>().SetBool("close", false);
            // Damos una peque�a espera despues de abrir la compuerta
            yield return new WaitForSeconds(1f);
        }

        // Mientras la distancia entre la posici�n actual y la posici�n objetivo sea mayor que una peque�a tolerancia
        while (Vector3.Distance(transform.position, posiciones[posicion].position) > 0.001f)
        {
            // Aplica el movimiento suave
            brazo.gameObject.transform.position = Vector3.SmoothDamp(brazo.gameObject.transform.position, posiciones[posicion].position, ref velocidad, tiempoSuavizado);

            // Pausa el ciclo hasta el siguiente frame
            yield return null;

            // Validamos si se esta cerrando la compuerta y activamos la animacion y verificamos que tenga una peque�a tolerancia de distancia antes de cerrar
            if (posicion == 1 && Vector3.Distance(brazo.gameObject.transform.position, posiciones[posicion].transform.position) < 0.5f)
            {
                plataforma.gameObject.GetComponent<Animator>().SetBool("open", false);
                plataforma.gameObject.GetComponent<Animator>().SetBool("close", true);
            }
        }

        // Una vez que se alcanza la posici�n objetivo, nos aseguramos de que el objeto est� exactamente en la posici�n objetivo
        brazo.gameObject.transform.position = posiciones[posicion].position;
    }  
}
