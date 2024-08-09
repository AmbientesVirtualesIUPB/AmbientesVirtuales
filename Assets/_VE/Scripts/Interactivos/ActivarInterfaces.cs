using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Clase que gestiona la activación y desactivación de interfaces y animaciones.
/// </summary>
public class ActivarInterfaces : MonoBehaviour
{
    /// <summary>
    /// Arreglo de interfaces (GameObjects) que se activarán o desactivarán.
    /// </summary>
    public GameObject[] interfaces;

    /// <summary>
    /// Referencia al objeto de texto que muestra el turno.
    /// </summary>
    //public Text Turno;

    /// <summary>
    /// Sistema de partículas que se reproduce al abrir.
    /// </summary>
    public ParticleSystem particulaAbrir;

    /// <summary>
    /// Sistema de partículas que se reproduce al cambiar de turno.
    /// </summary>
    public ParticleSystem particulaTurno;

    /// <summary>
    /// Referencia al componente Animator para controlar animaciones.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// Variable booleana que indica si el objeto está activado.
    /// </summary>
    private bool activado = false;

    /// <summary>
    /// Nombre de la animación que se controlará.
    /// </summary>
    public string NombreAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Obtener la referencia al componente Animator en el objeto actual.
        animator = this.GetComponent<Animator>();

        // Verificar si el objeto tiene Animator.
        if (animator == null)
        {
            Debug.LogError("El objeto no tiene Animator.");
        }
    }

    /// <summary>
    /// Método llamado cuando se interactúa con el objeto.
    /// </summary>
    public void Interactuo()
    {
        // Lógica de interacción (a implementar según necesidades).
    }

    /// <summary>
    /// Método llamado para encender alguna funcionalidad (a implementar según necesidades).
    /// </summary>
    public void Encender()
    {
        // Lógica de encendido (a implementar según necesidades).
    }

    /// <summary>
    /// Método llamado cuando otro collider entra en el trigger del objeto.
    /// </summary>
    /// <param name="other">Collider que entró en el trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el collider que entró tiene la etiqueta "Player".
        if (other.CompareTag("Player"))
        {
            // Activar la animación con el nombre especificado.
            activado = true;
            animator.SetBool(NombreAnim, activado);
        }
    }

    /// <summary>
    /// Método llamado cuando otro collider sale del trigger del objeto.
    /// </summary>
    /// <param name="other">Collider que salió del trigger.</param>
    private void OnTriggerExit(Collider other)
    {
        // Verificar si el collider que salió tiene la etiqueta "Player".
        if (other.CompareTag("Player"))
        {
            // Desactivar la animación con el nombre especificado.
            activado = false;
            animator.SetBool(NombreAnim, activado);
        }
    }
}