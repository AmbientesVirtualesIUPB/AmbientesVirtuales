using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InicializarFurtivo : MonoBehaviour
{
    public Transform[]  camsPositions;
    public GameObject[] botonesCanvas;
    public GameObject   camPrincipal;
    public GameObject   plataforma;
    public GameObject   brazo;
    public GameObject   canvas;
    public float        velocidad = 3;
    public float        duracion = 0.1f;
    private float       tiempoTranscurrido = 0f;
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
        float totalTime = 100f; // Duración total del ciclo en segundos
        float elapsedTime = 0f;

        // Mientras la distancia entre la posición actual y la posición objetivo sea mayor que una pequeña tolerancia
        while (elapsedTime < totalTime)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[0].position, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[0].rotation, velocidad * Time.deltaTime);
            // Pausa el ciclo hasta el siguiente frame
            elapsedTime+=1f;
            yield return null;
        }

        elapsedTime = 0f;
        yield return new WaitForSeconds(2f);

        while (elapsedTime < totalTime)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[1].position, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[1].rotation, velocidad * Time.deltaTime);

            if (elapsedTime == 90f)
            {
                canvas.gameObject.SetActive(true);
            }
            // Pausa el ciclo hasta el siguiente frame
            elapsedTime += 1f;
            yield return null;
        }

        camPrincipal.transform.position = camsPositions[1].position;
        camPrincipal.transform.rotation = camsPositions[1].rotation;

    }

    public void Salir()
    {
        StartCoroutine(SalirCanvas());
    }


    IEnumerator SalirCanvas()
    { 
        canvas.gameObject.GetComponent<Animator>().SetBool("hide", true);
        yield return new WaitForSeconds(0.8f);
        canvas.gameObject.SetActive(false);
        brazo.gameObject.GetComponent<BrazoGiratorio>().Detener();


        float totalTime = 200f; // Duración total del ciclo en segundos
        float elapsedTime = 0f;

        while (elapsedTime < totalTime)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, posicionInicial, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, rotacionInicial, velocidad * Time.deltaTime);
            // Pausa el ciclo hasta el siguiente frame
            elapsedTime += 1f;
            yield return null;
        }

        plataforma.gameObject.GetComponent<IniciarPlataforma>().MoverAbajo();
        yield return new WaitForSeconds(8f);
        collider.enabled = true;
    }


    public IEnumerator CambiarCamara(int num, int id)
    {
        tiempoTranscurrido = 0;

        if (id == 4 || id == 5)
        {
            botonesCanvas[0].gameObject.SetActive(false);
            botonesCanvas[1].gameObject.SetActive(false);
        }
        else
        {
            botonesCanvas[0].gameObject.SetActive(true);
            botonesCanvas[1].gameObject.SetActive(true);
        }

        if (camPrincipal.transform.position != camsPositions[num].position)
        {
            deshabilitarBotones(id);
            while (tiempoTranscurrido < duracion)
            {
                camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[num].position, tiempoTranscurrido / duracion);
                camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[num].rotation, tiempoTranscurrido / duracion);
                // Pausa el ciclo hasta el siguiente frame
                tiempoTranscurrido += Time.deltaTime;
                yield return null;
            }
            camPrincipal.transform.position = camsPositions[num].position;
            HabilitarBotones();
        }
    }

    public void deshabilitarBotones(int id)
    {
        for (int i = 2; i < botonesCanvas.Length; i++)
        {
            if (i != id)
            {
                botonesCanvas[i].gameObject.GetComponent<Button>().interactable = false;
            }
        }
    }

    public void HabilitarBotones()
    {
        for (int i = 0; i < botonesCanvas.Length; i++)
        {     
            botonesCanvas[i].gameObject.GetComponent<Button>().interactable = true;
            
        }
    }
}
