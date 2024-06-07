using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Certificados : MonoBehaviour
{
    // Referencia al canvas principal
    public GameObject canvas;

    // Referencia al componente Animator para controlar animaciones.
    Animator animator;

    // Nombre de la animación a controlar
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

    // Metodo invocado desde BtnCerti1 al solicitar el certificado 1
    public void Certificado1()
    {
        // Lógica (a implementar según necesidades)

        //Iniciamos currutina
        StartCoroutine(SalirInterfaz());
    }


    //Metodo invocado desde BtnCerti2 al solicitar el certificado 2
    public void Certificado2()
    {
        // Lógica (a implementar según necesidades)

        //Iniciamos currutina
        StartCoroutine(SalirInterfaz());
    }


    //Metodo invocado desde BtnCerti3 al solicitar el certificado 3
    public void Certificado3()
    {
        // Lógica (a implementar según necesidades)

        //Iniciamos currutina
        StartCoroutine(SalirInterfaz());
    }


    //Metodo invocado desde BtnCerti4 al solicitar el certificado 4
    public void Certificado4()
    {
        // Lógica (a implementar según necesidades)

        //Iniciamos currutina
        StartCoroutine(SalirInterfaz());
    }

    IEnumerator SalirInterfaz()
    {
        // Activamos la animacion
        animator.SetBool(nombreAnim, true);

        yield return new WaitForSeconds(0.5f);

        //Desactivamos la interfaz
        canvas.gameObject.SetActive(false);
    }
}
