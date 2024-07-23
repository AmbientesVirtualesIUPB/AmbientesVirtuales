using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InicializarFurtivo : MonoBehaviour
{
    public Transform[]  camsPositions;
    public GameObject   camPrincipal;
    public GameObject   plataforma;
    public GameObject   brazo;
    public GameObject   canvas;
    public float        velocidad = 3;
    private Collider    collider;
    private Vector3     posicionInicial;
    private Quaternion  rotacionInicial;

    private void Awake()
    {
        posicionInicial = camPrincipal.transform.position;
        rotacionInicial = camPrincipal.transform.rotation;
        collider = GetComponent<Collider>();
    }

    //Evento invocado al momento de hacer click con el mouse
    private void OnMouseDown()
    {
        //Activamos el objeto
        collider.enabled = false;
        StartCoroutine(MovimientoSuave());
        plataforma.gameObject.GetComponent<IniciarPlataforma>().MoverArriba(); 
    }

    IEnumerator MovimientoSuave()
    {
        int frames = 0;
        // Mientras la distancia entre la posición actual y la posición objetivo sea mayor que una pequeña tolerancia
        while (frames < 300)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[0].position, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[0].rotation, velocidad * Time.deltaTime);
            // Pausa el ciclo hasta el siguiente frame
            frames++;
            yield return null;
        }

        frames = 0;
        yield return new WaitForSeconds(2f);

        while (frames < 500)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[1].position, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[1].rotation, velocidad * Time.deltaTime);

            if (frames == 200)
            {
                canvas.gameObject.SetActive(true);
                brazo.gameObject.GetComponent<BrazoGiratorio>().sinPresionar = true;
            }
            // Pausa el ciclo hasta el siguiente frame
            frames++;
            yield return null;
        }

    }

    public void Salir()
    {
        StartCoroutine(SalirCanvas());
    }


    IEnumerator SalirCanvas()
    {
        
        canvas.gameObject.GetComponent<Animator>().SetBool("hide", true);
        yield return new WaitForSeconds(0.5f);
        canvas.gameObject.SetActive(false);
        brazo.gameObject.GetComponent<BrazoGiratorio>().Detener();

        
        int frames = 0;
        while (frames < 200)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, posicionInicial, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, rotacionInicial, velocidad * Time.deltaTime);
            // Pausa el ciclo hasta el siguiente frame
            frames++;
            yield return null;
        }

        plataforma.gameObject.GetComponent<IniciarPlataforma>().MoverAbajo();
        yield return new WaitForSeconds(7f);
        collider.enabled = true;
    }
}
