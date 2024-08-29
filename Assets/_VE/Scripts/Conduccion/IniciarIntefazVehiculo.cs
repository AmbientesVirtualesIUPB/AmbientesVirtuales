using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IniciarIntefazVehiculo : MonoBehaviour
{
    public Image[]  imagenes;
    public Text[]   textos;
    public Slider   slCarga;
    public Image    imgFill;
    public Bateria  bateria;
    public Conducir conducir;
    public float    duracionTransicion = 2f; // Duración en segundos para el efecto de fadein fadeout
    private float   tiempoTranscurrido = 0f; // Para medir el tiempo transcurrido en segundos
    private bool    estaEncendida;

    void Start()
    { 
        slCarga.value = 0;
        conducir.descargado = true;
    }

    /// <summary>
    /// Metodo invocado desde el boton BtnEncender en la escena
    /// </summary>
    public void InteractuarInterfaz()
    {
        if (conducir != null || bateria != null || slCarga !=null)
        {
            if (estaEncendida)
            {
                // Iniciar la corrutina para hacer el fade in
                StartCoroutine(OcultarImagenes());
                estaEncendida = false;
            }
            else
            {
                // Iniciar la corrutina para hacer el fade in
                StartCoroutine(MostrarImagenes());
                StartCoroutine(CargarBateria());
                estaEncendida = true;
            }
        }
        else
        {
            Debug.LogError("Falta inicializar componentes de la interfaz");
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
    IEnumerator MostrarImagenes()
    {
        imgFill.gameObject.SetActive(true);
        // Asegurarse de que el color inicial tenga alfa 0
        Color color = imagenes[0].color;
        color.a = 0;

        for (int i = 0; i < imagenes.Length - 1; i++)
        {
            imagenes[i].color = color;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = color;
        }


        // Iterar sobre el tiempo para aumentar el alfa
        tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < duracionTransicion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(tiempoTranscurrido / duracionTransicion);
            color.a = newAlpha;

            for (int i = 0; i < imagenes.Length; i++)
            {
                imagenes[i].color = color;
            }
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].color = color;
            }
            yield return null;
        }

        // Asegurarse de que el alfa final sea 1 (completamente opaco)
        color.a = 1f;
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].color = color;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = color;
        }

        // Ya no se puede manejar
        bateria.funcionar = true; // Indicamos que la bateria esta funcionando
        conducir.descargado = false; // Indicamos que el vehiculo se puede conducir, siempre y cuando tenga carga
        slCarga.enabled = true; // Habilitamos el slider para evitar errores
    }

    /// <summary>
    /// Currutina encargada para ocultar las imagenes y los textos disminuyendoles el alfa
    /// </summary>
    IEnumerator OcultarImagenes()
    {
        // Ya no se puede manejar
        bateria.funcionar = false; // Indicamos que la bateria no esta funcionando
        conducir.descargado = true; // Indicamos que el vehiculo no se puede conducir, sin importar que tenga carga
        slCarga.enabled = false; // Deshabilitamos el slider para evitar errores

        // Asegurarse de que el color inicial tenga alfa 1 (completamente opaco)
        Color color = imagenes[0].color;
        color.a = 1;

        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].color = color;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = color;
        }

        // Iterar sobre el tiempo para disminuir el alfa
        tiempoTranscurrido = 0f;
        while (tiempoTranscurrido < duracionTransicion)
        {
            tiempoTranscurrido += Time.deltaTime;
            float newAlpha = Mathf.Clamp01(1 - (tiempoTranscurrido / duracionTransicion));
            color.a = newAlpha;

            for (int i = 0; i < imagenes.Length; i++)
            {
                imagenes[i].color = color;
            }
            for (int i = 0; i < textos.Length; i++)
            {
                textos[i].color = color;
            }
            yield return null;
        }

        // Asegurarse de que el alfa final sea 0 (completamente transparente)
        color.a = 0f;
        for (int i = 0; i < imagenes.Length; i++)
        {
            imagenes[i].color = color;
        }
        for (int i = 0; i < textos.Length; i++)
        {
            textos[i].color = color;
        }

        imgFill.gameObject.SetActive(false);  
    }
}
