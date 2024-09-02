using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniciarIntefazVehiculo : MonoBehaviour
{
    public Image[]  imagenes; // Referencia de las imagenes a las cuales se les quiere modificar el valor de alfa
    public Text[]   textos; // Referencia de los textos a las cuales se les quiere modificar el valor de alfa
    public Image    btnImagen; // Referencia al boton de encendido para modificarle el color
    public Slider   slCarga; // Referencia a la bateria para darle un efecto de carga
    public Bateria  bateria; // Referencia de script
    public Conducir conducir; // Referencia de script
    public float    duracionTransicion = 2f; // Duración en segundos para el efecto de fadein fadeout
    private float   tiempoTranscurrido = 0f; // Para medir el tiempo transcurrido en segundos
    private bool    estaEncendida; // Para validar el estado del panelo
    private bool    flag; // Bandera


    void Start()
    { 
        slCarga.value = 0; // Damos un valor inicial a la bateria para posteriormente aumentar
        conducir.descargado = true; // Indicamos que inicialmente no se puede conducir hasta ser encendido
    }

    /// <summary>
    /// Metodo invocado desde el boton BtnEncender en la escena
    /// </summary>
    public void InteractuarInterfaz()
    {
        // Validamos que los componentes esten asignaods
        if (bateria == null || conducir == null || imagenes.Length == 0 || textos.Length == 0 || btnImagen == null || slCarga == null)
        {
            Debug.LogError("falta inicializar componentes en el script IniciarInterfazVehiculo");

        }
        else
        {
            
            // Validamos si la interfaz esta apagada o encendida
            if (estaEncendida)
            {
                if (flag)
                {
                    // Iniciar la corrutina para hacer el fade out
                    StartCoroutine(OcultarInterfaz());
                    estaEncendida = false;
                }
            }
            else
            {
                if (!flag)
                {
                    // Iniciar la corrutina para hacer el fade in
                    StartCoroutine(MostrarInterfaz());
                    StartCoroutine(CargarBateria());
                    estaEncendida = true;
                }
            }
        }   
    }

    /// <summary>
    /// Currutina encargada de realizar la carga visual de la bateria
    /// </summary>
    IEnumerator CargarBateria()
    {
        while (tiempoTranscurrido < duracionTransicion)
        {
            slCarga.value = tiempoTranscurrido / duracionTransicion;
            yield return null;
        }
    }

    /// <summary>
    /// Currutina encargada para mostrar las imagenes y los textos aumentandoles el alfa
    /// </summary>
    IEnumerator MostrarInterfaz()
    {
        //Cambiamos el color del boton a verde = encendido
        btnImagen.color = Color.green;

        // Guardamos una referencia de los colores originales
        Color colorTexto = textos[0].color; // Referencia de los textos
        colorTexto.a = 0;
        Color[] coloresOriginalesImagenes = new Color[imagenes.Length]; // Referencia de las imagenes

        // Asegurarse de que los colores iniciales tengan alfa 0
        for (int i = 0; i < imagenes.Length; i++)
        {
            // Establece el alfa en 0 pero preserva el color original
            coloresOriginalesImagenes[i] = imagenes[i].color;
            Color colorImagen = coloresOriginalesImagenes[i];
            colorImagen.a = 0;
            imagenes[i].color = colorImagen;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = colorTexto;
        }


        // Iterar sobre el tiempo para aumentar el alfa
        tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < duracionTransicion)
        {
            tiempoTranscurrido += Time.deltaTime;
            // Limitamos el valor del nuevo alfa entre 0 y 1 Mathf.Clamp01
            float newAlpha = Mathf.Clamp01(tiempoTranscurrido / duracionTransicion);
            colorTexto.a = newAlpha;

            // Modificamos el alfa tanto en las imagenes como en los textos
            for (int i = 0; i < imagenes.Length; i++)
            {
                Color colorImagen = coloresOriginalesImagenes[i];
                colorImagen.a = newAlpha;
                imagenes[i].color = colorImagen;
            }
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].color = colorTexto;
            }
            yield return null;
        }

        // Asegurarse de que el alfa final sea 1 (completamente opaco)
        colorTexto.a = 1f;
        for (int i = 0; i < imagenes.Length; i++)
        {
            Color colorImagen = coloresOriginalesImagenes[i];
            colorImagen.a = 1f;
            imagenes[i].color = colorImagen;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = colorTexto;
        }

        // Indicamos que Ya se puede conducir
        bateria.funcionar = true; // Indicamos que la bateria esta funcionando
        conducir.descargado = false; // Indicamos que el vehiculo se puede conducir, siempre y cuando tenga carga
        slCarga.enabled = true; // Habilitamos el slider para evitar errores
        flag = true;
    }

    /// <summary>
    /// Currutina encargada para ocultar las imagenes y los textos disminuyendoles el alfa
    /// </summary>
    IEnumerator OcultarInterfaz()
    {
        //Cambiamos el color del boton a rojo = apagado
        btnImagen.color = Color.red;

        // Indicamos que Ya no se puede manejar
        bateria.funcionar = false; // Indicamos que la bateria no esta funcionando
        conducir.descargado = true; // Indicamos que el vehiculo no se puede conducir, sin importar que tenga carga
        slCarga.enabled = false; // Deshabilitamos el slider para evitar errores

        // Guardamos una referencia de los colores originales
        Color colorTexto = textos[0].color; // Referencia de los textos
        colorTexto.a = 1;
        Color[] coloresOriginalesImagenes = new Color[imagenes.Length]; // Referencia de las imagenes

        // Asegurarse de que los colores iniciales tengan alfa 1
        for (int i = 0; i < imagenes.Length; i++)
        {
            // Establece el alfa en 0 pero preserva el color original
            coloresOriginalesImagenes[i] = imagenes[i].color;
            Color colorImagen = coloresOriginalesImagenes[i];
            colorImagen.a = 1;
            imagenes[i].color = colorImagen;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = colorTexto;
        }

        // Iterar sobre el tiempo para aumentar el alfa
        tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < duracionTransicion)
        {
            tiempoTranscurrido += Time.deltaTime;
            // Limitamos el valor del nuevo alfa entre 0 y 1 Mathf.Clamp01 y de forma negativa
            float newAlpha = Mathf.Clamp01(1- tiempoTranscurrido / duracionTransicion);
            colorTexto.a = newAlpha;

            // Modificamos el alfa tanto en las imagenes como en los textos
            for (int i = 0; i < imagenes.Length; i++)
            {
                Color colorImagen = coloresOriginalesImagenes[i];
                colorImagen.a = newAlpha;
                imagenes[i].color = colorImagen;
            }
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].color = colorTexto;
            }
            yield return null;
        }

        // Asegurarse de que el alfa final sea 1 (completamente invisible)
        colorTexto.a = 0f;
        for (int i = 0; i < imagenes.Length; i++)
        {
            Color colorImagen = coloresOriginalesImagenes[i];
            colorImagen.a = 0f;
            imagenes[i].color = colorImagen;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = colorTexto;
        }

        flag = false;
    }
}
