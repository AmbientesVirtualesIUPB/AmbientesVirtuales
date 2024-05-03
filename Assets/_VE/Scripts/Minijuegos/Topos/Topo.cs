// Importa las bibliotecas necesarias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script que controla el comportamiento de un topo en un juego.
/// </summary>
[RequireComponent(typeof(Animator))]
public class Topo : MonoBehaviour
{
    /// <summary>
    /// Indica si el topo está activo (visible y puede ser golpeado).
    /// </summary>
    public bool activo = true;

    /// <summary>
    /// Referencia al componente Animator del topo.
    /// </summary>
    private Animator anims;

    /// <summary>
    /// Sistema de partículas asociado al topo.
    /// </summary>
    public ParticleSystem particulas;

    /// <summary>
    /// Se ejecuta al inicio del script.
    /// </summary>
    void Start()
    {
        // Obtiene la referencia al componente Animator.
        anims = GetComponent<Animator>();

        // Inicia la rutina que controla la visibilidad intermitente del topo.
        StartCoroutine(TopoActivo());

        // Si no se ha asignado un sistema de partículas, busca uno en los hijos del topo.
        if (particulas == null)
        {
            particulas = GetComponentInChildren<ParticleSystem>();
        }
    }

    /// <summary>
    /// Rutina que controla la visibilidad intermitente del topo.
    /// </summary>
    IEnumerator TopoActivo()
    {
        // Bucle infinito para que la rutina se ejecute continuamente.
        while (true)
        {
            // Espera hasta que el topo esté activo.
            yield return new WaitUntil(() => activo);

            // Bucle mientras el topo está activo.
            while (activo)
            {
                // Espera un tiempo aleatorio entre 3 y 10 segundos.
                yield return new WaitForSeconds(Random.Range(3f, 10f));

                // Hace visible al topo.
                anims.SetBool("visible", true);

                // Espera 1 segundo.
                yield return new WaitForSeconds(1f);

                // Oculta al topo.
                anims.SetBool("visible", false);
            }
        }
    }

    // Método que realiza la acción de golpear al topo.
    void Golpear()
    {
        // Verifica si el topo está visible.
        if (anims.GetBool("visible"))
        {
            // Si hay un sistema de partículas asignado, lo reproduce.
            if (particulas != null)
            {
                particulas.Play();
            }
        }
    }

    // Se ejecuta cuando se hace clic en el topo.
    private void OnMouseDown()
    {
        // Llama al método Golpear al hacer clic en el topo.
        Golpear();
    }

    // Se ejecuta cuando otro collider entra en el trigger del topo.
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el collider es el mazo y golpea al topo.
        if (other.CompareTag("Mazo"))
        {
            Golpear();
        }
    }
}
