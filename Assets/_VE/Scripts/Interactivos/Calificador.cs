using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calificador : MonoBehaviour
{
    // Referencia al canvas principal
    public GameObject canvas;

    /// Referencia al componente Animator para controlar animaciones.
    Animator animator;


    /// Nombre de la animación a controlar
    public string nombreAnim;

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

    // Metodo invocado desde BtnExcelente al calificar excelente
    public void Excelente()
    {
        // Lógica (a implementar según necesidades)

        StartCoroutine(SalirInterfaz());
    }


    // Metodo invocado desde BtnBueno al calificar bueno
    public void Bueno()
    {
        // Lógica (a implementar según necesidades)

        StartCoroutine(SalirInterfaz());
    }


    // Metodo invocado desde BtnRegular al calificar regular
    public void Regular()
    {
        // Lógica (a implementar según necesidades)

        StartCoroutine(SalirInterfaz());
    }


    // Metodo invocado desde BtnMalo al calificar malo
    public void Malo()
    {
        // Lógica (a implementar según necesidades)

        StartCoroutine(SalirInterfaz());
        
    }

    IEnumerator SalirInterfaz()
    {
        // Activamos la animacion
        animator.SetBool(nombreAnim, true);

        yield return new  WaitForSeconds(0.5f);

        // Desactivamos la interfaz
        canvas.gameObject.SetActive(false);
    }
}
