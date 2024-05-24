using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SolicitaTurno : MonoBehaviour
{
    // Referencia al objeto que muestra el turno.
    public GameObject Turno;

    // Referencia al texto para poder modificar el numero del turno
    public TextMeshProUGUI TurnoText;

    // Referencia al componente Animator para controlar animaciones.
    Animator animator;
    
    new
    // Referencia al componente Collider para controlar colisiones.
    Collider collider;


    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos referencia al animator del objeto Turno
        animator = Turno.GetComponent<Animator>();

        //Obtenemos collider del objeto padre
        collider = this.GetComponent<Collider>();
    }


    // Evento invocado al momento de hacer click con el mouse
    private void OnMouseDown()
    {
        // Iniciamos currutina
        StartCoroutine(DarTurno());
    }

    IEnumerator DarTurno()
    {
        // Deshabilitamos colider para asegurarnos que solo se pueda pedir un turno hasta que termine la animacion
        collider.enabled = false;

        // Activamos el objeto Turno e iniciamos su animación
        Turno.gameObject.SetActive(true);
        animator.SetBool("mostrar", true);

        yield return new WaitForSeconds(4f);

        // Desactivamos el objeto nuevamente para que no se vea en scena
        Turno.gameObject.SetActive(false);

        // Habilitamos nuevamente el collider
        collider.enabled = true;
    }
}
