using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InicializarFurtivo : MonoBehaviour
{
    public Transform[]  camsPositions;
    public GameObject[] botonesCanvas;
    public Transform    camPrincipal;
    public GameObject   plataforma;
    public GameObject   brazo;
    public GameObject   canvas;
    public GameObject   canvasPantalla;
    private Collider    collider;

    //Variables para el manejo de camaras
    public float        velocidad = 3;           // Velocidad de interpolación
    private float       lerpTime = 0.0f;        // Tiempo de interpolación
    public float        lerpDuration = 2.0f;    // Duración de la interpolación
    public bool         iniciarCamaras = false; // Variable para determinar cuando podemos mover posiciones de camara

    // Vectores con las variables para almacenar las posiciones y rotaciones
    private Vector3     posicionInicial;
    private Quaternion  rotacionInicial;
    private Vector3     posicion;
    private Quaternion  rotacion;
    

    /// <summary>
    /// Metodo invocado antes de iniciar la scena
    /// </summary>
    private void Awake()
    {
        collider = GetComponent<Collider>();
    }
    

    /// <summary>
    /// Metodo invocado al iniciar la scena
    /// </summary>
    private void Start()
    {
        // Guardamos la posicion que tenemos antes de iniciar la personalizacion
        posicionInicial = camPrincipal.transform.position;
        rotacionInicial = camPrincipal.transform.rotation;

        // Guardamos la posicion que tendra inicialmente la interfaz
        posicion = camsPositions[1].transform.position;
        rotacion = camsPositions[1].transform.rotation;
    }


    /// <summary>
    /// Metodo invocado frame a frame
    /// </summary>
    void Update()
    {
        // Validamos si ya podemos hacer cambios de camaras
        if (iniciarCamaras)
        {
            // Si el enfoque actual es diferente a nuestra camara ejecutamos
            if (camPrincipal.position != posicion)
            {
                // Asignamos un tiempo, velocidad y guardamos posicion y rotacion de la nueva posicion
                lerpTime += Time.deltaTime / lerpDuration;
                camPrincipal.position = Vector3.Lerp(camPrincipal.position, posicion, lerpTime);
                camPrincipal.rotation = Quaternion.Lerp(camPrincipal.rotation, rotacion, lerpTime);
            }
        } 
    }


    /// <summary>
    /// Metodo invocado desde los botones del canvas para indicar que enfoque le daremos a la camara
    /// </summary>
    /// <param name="index"> Indica el valor para la posicion de la variable camsPositions </param>
    public void MoverPosicion(int index)
    {
        // Validamos si el enfoque de la camara es diferente al enfoque de la silla o del volante para inhabilitar las flechas de movimiento
        if (index > 1)
        {
            botonesCanvas[0].gameObject.SetActive(false);
            botonesCanvas[1].gameObject.SetActive(false);
        }
        else
        {
            botonesCanvas[0].gameObject.SetActive(true);
            botonesCanvas[1].gameObject.SetActive(true);
        }
        // Asignamos la posicion y rotacion dependiendo del index o de la posicion de la camara
        posicion = camsPositions[index].position;
        rotacion = camsPositions[index].rotation;
        lerpTime = 0.0f;  // Reiniciar el tiempo de interpolación
    }


    /// <summary>
    /// Evento invocado al momento de hacer click con el mouse
    /// </summary>
    private void OnMouseDown()
    {
        // Deshabilitamos el collider para evitar que no se siga oprimiendo
        collider.enabled = false;
        // Inicializamos la animacion para la plataforma
        plataforma.gameObject.GetComponent<IniciarPlataforma>().MoverArriba();
        // Activamos las baterias para que no se vean en escena
        plataforma.gameObject.GetComponent<PersonalizacionFurtivo>().baterias.gameObject.SetActive(true);
        // Iniciamos currutinas para cambios de camara e inicio de interfaz
        StartCoroutine(MovimientoSuave());
    }


    /// <summary>
    /// Currutina para dar un movimiento suavizado a los cambios de camara y preparacion de la plataforma
    /// </summary>
    IEnumerator MovimientoSuave()
    {
        //Activamos el canvas con la pantalla del vehiculo
        canvasPantalla.gameObject.SetActive(true);

        float tiempoTotal = 300f; // Duración total del ciclo en segundos
        float tiempoTranscurrido = 0f; // Validamos el tiempo transcurrido

        // Mientras que el tiempo transcurrido sea menor al total indicado
        while (tiempoTranscurrido < tiempoTotal)
        {
            // Hacemos el primer cambio de camara
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[0].position, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[0].rotation, velocidad * Time.deltaTime);

            // Pausa el ciclo hasta el siguiente frame
            tiempoTranscurrido += 1f;
            yield return null;
        }

        // Reiniciamos el tiempo transcurrido
        tiempoTranscurrido = 0f;
        // Esperamos 4.5 segundos
        yield return new WaitForSeconds(4.5f);

        // Mientras que el tiempo transcurrido sea menor al total indicado
        while (tiempoTranscurrido < tiempoTotal)
        {
            // Hacemos el segundo cambio de camara
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[1].position, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[1].rotation, velocidad * Time.deltaTime);
            tiempoTranscurrido += 1f;
            yield return null;
        }  

        // Confirmamos que la camara quede con la posicon deseada
        camPrincipal.transform.position = camsPositions[1].position;
        camPrincipal.transform.rotation = camsPositions[1].rotation;
        // Habilitamos el canvas
        canvas.gameObject.SetActive(true);
        // Indicamos que ya podemos hacer cambios de camaras
        iniciarCamaras = true;
    }


    /// <summary>
    /// Metodo invocado desde BtnSalir en nuestro canvas
    /// </summary>
    public void Salir()
    {
        // Indicamos que ya no podemos hacer cambios de camaras
        iniciarCamaras = false;
        // Iniciamos currutina de salida
        StartCoroutine(SalirCanvas());
    }


    /// <summary>
    /// Currutina que se ejecuta al salir de la personalizacion
    /// </summary>
    IEnumerator SalirCanvas()
    { 
        // Iniciamos la animacion que tiene el canvas
        canvas.gameObject.GetComponent<Animator>().SetBool("hide", true);
        // esperamos 0.8 segundos
        yield return new WaitForSeconds(0.8f);
        // Deshabilitamos canvas
        canvas.gameObject.SetActive(false);
        // Detenemos el brazo y se posiciona en la parte inicial
        brazo.gameObject.GetComponent<BrazoGiratorio>().Detener();
        // Desactivamos las baterias para que no se vean en escena
        plataforma.gameObject.GetComponent<PersonalizacionFurtivo>().baterias.gameObject.SetActive(false);


        float tiempoTotal = 200f; // Duración total del ciclo en segundos
        float tiempoTranscurrido = 0f; // Tiempo transcurrido del ciclo

        // Mientras que el tiempo transcurrido sea menor al total indicado realiza el cambio de camara
        while (tiempoTranscurrido < tiempoTotal)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, posicionInicial, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, rotacionInicial, velocidad * Time.deltaTime);
            // Pausa el ciclo hasta el siguiente frame
            tiempoTranscurrido += 1f;
            yield return null;
        }

        //Activamos el canvas con la pantalla del vehiculo
        canvasPantalla.gameObject.SetActive(false);

        // Iniciamos la animacion de esconder del brazo de la plataforma
        plataforma.gameObject.GetComponent<IniciarPlataforma>().MoverAbajo();
        yield return new WaitForSeconds(7f);

        // Confirmamos que la ultima posicion sea la inicial antes de la personalizacion
        posicion = camsPositions[1].transform.position;
        rotacion = camsPositions[1].transform.rotation;

        // Confirmamos que al salir las flechas de movimiento queden activas
        botonesCanvas[0].gameObject.SetActive(true);
        botonesCanvas[1].gameObject.SetActive(true);

        // Habilitamos nuevamente el collider
        collider.enabled = true;
    }

}
