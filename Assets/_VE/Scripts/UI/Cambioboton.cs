using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cambioboton : MonoBehaviour
{
    //Variables para el manejo del panel derecho
    public RectTransform[]  botones;
    public int              conteo = 0;
    public RectTransform[]  Posiciones;

    //Variables para el control del Zoom
    int enfoqueActual = 0;
    public GameObject       panelZoom;
    public GameObject       canvasZoom;

    //Posiciones de camaras
    public GameObject       camPrincipal;
    public float            velocidad = 3;
    private Vector3         posicionInicial;
    private Quaternion      rotacionInicial;
    public bool             enZoom = false;
    public Transform[]      camsPositions;
    public GameObject[]     panelesColor;

    private void Awake()
    {
        posicionInicial = camPrincipal.transform.position;
        rotacionInicial = camPrincipal.transform.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        Actualizar();
    }

    private void Update()
    {
        Zoom2();
    }

    /// <summary>
    /// Metodo invocado para actualizar el canvas con los botones de personalizacion segun el enfoque
    /// </summary>
    void Actualizar()
    {
        //Activamos la posición central y habilitamos el botón de personalizacion correspondiente
        botones[conteo % 8].gameObject.SetActive(true);
        botones[conteo % 8].gameObject.GetComponent<Button>().interactable = true;
        botones[conteo % 8].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1f);
        botones[conteo % 8].position = Posiciones[1].position;
        
        //Habilitamos la posicion izquierda pero solo para visualización, no para uso
        botones[(conteo + 1) % 8].gameObject.SetActive(true);
        botones[(conteo + 1) % 8].position = Posiciones[0].position;
        botones[(conteo + 1) % 8].gameObject.GetComponent<Button>().interactable = false;
        botones[(conteo + 1) % 8].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);

        //Habilitamos la posicion derecha pero solo para visualización, no para uso
        botones[(conteo + 7) % 8].gameObject.SetActive(true);
        botones[(conteo + 7) % 8].position = Posiciones[2].position;
        botones[(conteo + 7) % 8].gameObject.GetComponent<Button>().interactable = false;
        botones[(conteo + 7) % 8].gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);

        //Mientras tanto Desactivamos los botones que no estan en nuestra visual
        botones[(conteo + 2) % 8].gameObject.SetActive(false);
        botones[(conteo + 3) % 8].gameObject.SetActive(false);
        botones[(conteo + 4) % 8].gameObject.SetActive(false);
        botones[(conteo + 5) % 8].gameObject.SetActive(false);
        botones[(conteo + 6) % 8].gameObject.SetActive(false);


        //Verificamos que objeto hijo esta marcado como interactuable en el momento para saber que enfoque le daremos al Zoom
        for (int i = 0; i < botones.Length; i++)
        {
            if (transform.GetChild(conteo).gameObject.GetComponent<Button>().interactable == true)
            {
                enfoqueActual = conteo + 1;
            }
        }
        
        // Activamos el hijo del canvas zoom, dependiendo del enfoque actual activo
        for (int i = 0; i < 8; i++)
        {
            canvasZoom.transform.GetChild(i).gameObject.SetActive((enfoqueActual - 1) == i);
        }     
    }

    /// <summary>
    /// Metodos invocados desde BtnDerecha en escena para cambiar entre botones de personalizacion
    /// </summary>
    public void PasaDerecha()
    {
        conteo = (conteo + 8 + 1) % 8;

        BotonesDescat();
    }

    /// <summary>
    /// Metodos invocados desde BtnIzquierda en escena para cambiar entre botones de personalizacion
    /// </summary>
    public void PasaIzquierda()
    {
        conteo = (conteo + 8 - 1) % 8;

        BotonesDescat();
    }

    /// <summary>
    /// Para desactivar o activar el canvas con los colores dentro del zoom
    /// </summary>
    public void BotonesDescat() 
    {
        // Activar/Desactivar barras color
        if (conteo == 0)
        {
            panelesColor[0].SetActive(true);
            panelesColor[1].SetActive(true);
        }
        else
        {
            panelesColor[0].SetActive(false);
            panelesColor[1].SetActive(false);
        }

        if (conteo == 2)
        {
            panelesColor[2].SetActive(true);
        }
        else
        {
            panelesColor[2].SetActive(false);
        }

        if (conteo == 3)
        {
            panelesColor[3].SetActive(true);
        }
        else
        {
            panelesColor[3].SetActive(false);
        }

        if (conteo == 6)
        {
            panelesColor[4].SetActive(true);
        }
        else
        {
            panelesColor[4].SetActive(false);
        }
        // Actualizamos el canvas
        Actualizar();
    }

    /// <summary>
    /// Metodo invocado desde BtnZoom en scena para iniciar el Zoom segun el enfoque actual
    /// </summary>
    public void Zoom()
    {
        enZoom = true;
        //Activamos el panelzoom para evitar que se opriman botones del PANEL DERECHO mientras se ejecuta el metodo Zoom
        panelZoom.gameObject.SetActive(enZoom);

        //Habilitamos el Canvas del zoom
        canvasZoom.gameObject.SetActive(enZoom);

        for (int i = 0; i < 8; i++)
        {
            canvasZoom.transform.GetChild(i).gameObject.SetActive((enfoqueActual - 1)==i);
        }
    }


    /// <summary>
    /// Metodo invocado desde BtnSalirZoom en scena para volver al menu de personalizacion inicial
    /// </summary>
    public void SalirZoom()
    {
        enZoom = false;
        //Activamos el panelzoom para evitar que se opriman botones del PANEL DERECHO mientras se ejecuta el metodo Zoom
        panelZoom.gameObject.SetActive(enZoom);

        //Habilitamos el Canvas del zoom
        canvasZoom.gameObject.SetActive(enZoom);

        for (int i = 0; i < 8; i++)
        {
            canvasZoom.transform.GetChild(i).gameObject.SetActive(false);
        }
    }



    /// <summary>
    /// Metodo invocado en el Update para actualizar las posiciones de camara
    /// </summary>
    public void Zoom2()
    {
        if (!enZoom)
        {
            camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, posicionInicial, velocidad * Time.deltaTime);
            camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, rotacionInicial, velocidad * Time.deltaTime);
            return;
        }

        camPrincipal.transform.position = Vector3.Lerp(camPrincipal.transform.position, camsPositions[enfoqueActual].position,velocidad*Time.deltaTime);
        camPrincipal.transform.rotation = Quaternion.Lerp(camPrincipal.transform.rotation, camsPositions[enfoqueActual].rotation,velocidad*Time.deltaTime);
    }
}
