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
    public bool         ocupado = false;
    public Respuesta    respuesta;


    //Currutina para invocar los servicios
    public IEnumerator ConsumirServicio(string nombre, string[] datos, UnityAction e)
    {
        ocupado = true;
        //Formulario donde estan los datos a enviar
        WWWForm formulario = new WWWForm();
        //Obtenemos el servicio
        Servicio s = new Servicio();
        for (int i = 0; i < servicios.Length; i++)
        {
            if (servicios[i].nombre.Equals(nombre))
            {
                s = servicios[i];
            }
        }

        //Añadir los campos de los servicios
        for (int i = 0; i < s.parametros.Length; i++)
        {
            formulario.AddField(s.parametros[i], datos[i]);
        }

        //Hacemos la solicitud a internet enviando la URl a utilizar
        UnityWebRequest www = UnityWebRequest.Post(servidor + "/" + s.URL, formulario);
        Debug.Log(servidor + "/" + s.URL);

        yield return www.SendWebRequest();

        //validamos si llego la respuesta de internet
        if (www.result != UnityWebRequest.Result.Success)
        {
            respuesta = new Respuesta();
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            //Convertimos el Json a una cloase tipo Respuesta
            respuesta = JsonUtility.FromJson<Respuesta>(www.downloadHandler.text);
            respuesta.LimpiarRespuesta();

        }
        ocupado = false;

        //Cuando se llama cada uno de los servicios se invoca el evento especifico
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
        respuesta = respuesta.Replace('#', '"');
    }

    //Respuestas erradas
    public Respuesta()
    {
        codigo = 404;
        mensaje = "Error";
    }

}


[System.Serializable]
public class DBusuario
{
    public int id;
    public string nombre;
    public string pass;
    public int jugador;
    public int nivel;
}