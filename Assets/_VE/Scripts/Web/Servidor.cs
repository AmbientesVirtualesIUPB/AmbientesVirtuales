using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


[CreateAssetMenu(fileName = "Servidor", menuName = "Principal/Servidor", order = 1)]
public class Servidor : ScriptableObject
{
    //Creacion de servidor con sus respectivos servicios
    public string       servidor;
    public Servicio[]   servicios;

    //Para validar si en el momento se consume un servicio
    public bool         ocupado;
    public Respuesta    respuesta;


    //Currutina para invocar los servicios a consumir, nombre=servicio a consumir, datos= que se enviaran como parametros
    public IEnumerator ConsumirServicio(string nombre, string[] datos, UnityAction e)
    {
        ocupado = true;
        // Formulario donde estan los datos a enviar
        WWWForm formulario = new WWWForm();
        // Obtenemos el servicio
        Servicio s = null;
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
                break;
            }
        }

        if (s == null)
        {
            Debug.LogError("Servicio no encontrado: " + nombre);
            ocupado = false;
            yield break;
        }

        // Añadir los campos de los servicios
        for (int i = 0; i < s.parametros.Length; i++)
        {
            // Uno a uno añadimos cada parametro a datos[]
            formulario.AddField(s.parametros[i], datos[i]);
        }

        // Hacemos la solicitud a internet enviando la URL a utilizar
        UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.URL, formulario);
        Debug.Log(servidor + "/" + s.URL);

        yield return www.SendWebRequest();

        // validamos si llegó la respuesta de internet
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error en la solicitud: " + www.error);
            respuesta = new Respuesta();
        }
        else
        {
            string jsonResponse = www.downloadHandler.text;
            Debug.Log("Respuesta del servidor: " + jsonResponse);

            try
            {
                // Convertimos el Json a una clase tipo Respuesta
                respuesta = JsonUtility.FromJson<Respuesta>(jsonResponse);
                respuesta.LimpiarRespuesta();
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error al parsear JSON: " + ex.Message);
                Debug.LogError("JSON recibido: " + jsonResponse);
                respuesta = new Respuesta();
            }
        }
        ocupado = false;

        // Cuando se llama cada uno de los servicios se invoca el evento especifico
        e.Invoke();

    }
}


[System.Serializable]
public class Servicio
{
    //Para acceder el servicio desde un archivo PHP y con X parametros
    public string   nombre;
    public string   URL;
    public string[] parametros;
}


[System.Serializable]
public class Respuesta
{
    //Para las respuestas del formato JSON
    public int      codigo;
    public string   mensaje;
    public string   respuesta;

    //Para arreglar los numerales
    public void LimpiarRespuesta()
    {
        //respuesta = respuesta.Replace('#', '"');
    }

    //Consutructor Respuestas erradas
    public Respuesta()
    {
        codigo = 404;
        mensaje = "Error";
    }
}


[System.Serializable]
public class DBusuario
{
    public int      id;
    public string   usuario;
    public string   pass;
    public int      jugador;
    public int      nivel;
}