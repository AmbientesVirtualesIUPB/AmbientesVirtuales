using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class ConsumirAPI : MonoBehaviour
{
    [Serializable]
    // Clase que Representa los datos que enviar�s en la solicitud POST
    public class SolicitudLogin
    {
        public string Email;
        public string Contrase�a;
    }

    [Serializable]
    // Clase que Representa los datos anidados dentro de la respuesta
    public class DatosRespuesta
    {
        public string Identificacion;
        public string NombreCompleto;
        public string TipoDeUsuario;
        public string Programa;
        public string Facultad;
    }

    [Serializable]
    // Clase que Representa la respuesta general que contiene un booleano de �xito, un mensaje, y los datos de respuesta
    public class LoginRespuesta
    {
        public bool             Estado;
        public string           Mensaje;
        public DatosRespuesta   Datos;
    }

    // Solicitamos una referencia a los InputField del login
    public TMP_InputField       InputUsuario;
    public TMP_InputField       InputPassword;

    // Establecemos las variables, con los datos de la url a consumir y su llave de autenticacion
    private string apiUrl = "https://sicau.pascualbravo.edu.co/SICAU/API/ServicioLogin/LoginAmbientesVirtuales";
    private string apiKey = "s1c4uc0ntr0ld34cc3s02019*";


    //Metodo invocado desde el bot�n Iniciar en el Login
    public void Consumir()
    {
        // Crear un objeto con los datos que queremos enviar
        SolicitudLogin solicitudLogin = new SolicitudLogin
        {    
            Email = InputUsuario.text,
            Contrase�a = InputPassword.text
        };

        // Convertir el objeto a JSON
        string jsonDato = JsonUtility.ToJson(solicitudLogin);

        // Iniciar la corrutina para enviar los datos
        StartCoroutine(PostData(jsonDato));
    }

    IEnumerator PostData(string jsonDato)
    {
        // Crear una solicitud POST, donde le enviamos la URL a consumir
        UnityWebRequest solicitud = new UnityWebRequest(apiUrl, "POST");
        // Convertir el JSON a bytes y adjuntar a la solicitud
        byte[] jsonAEnviar = new System.Text.UTF8Encoding().GetBytes(jsonDato);
        // Adjuntamos los datos JSON al cuerpo de la solicitud
        solicitud.uploadHandler = new UploadHandlerRaw(jsonAEnviar);
        // Recibe la respuesta en el buffer para su almacenamiento
        solicitud.downloadHandler = new DownloadHandlerBuffer();

        // Establecemos las cabeceras necesarias para indicar que los datos son JSON y a�adimos la clave de autenticaci�n (Authorization en este caso).
        solicitud.SetRequestHeader("Content-Type", "application/json");
        solicitud.SetRequestHeader("Authorization", apiKey);

        // Enviamos la solicitud y esperamos la respuesta
        yield return solicitud.SendWebRequest();

        // Comprobamos si hay errores en la solicitud
        if (solicitud.result == UnityWebRequest.Result.ConnectionError || solicitud.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + solicitud.error);
            Debug.LogError("Codigo de respuesta: " + solicitud.responseCode);
            Debug.LogError("URL: " + solicitud.url);
        }
        else
        {
            // Sino se encuentra ningun error obtenemos la respuesta en formato JSON
            string respuestaJson = solicitud.downloadHandler.text;
            LoginRespuesta loginResponse = JsonUtility.FromJson<LoginRespuesta>(respuestaJson);
            // Si la respuesta es exitosa el estado de la consulta es verdadero
            loginResponse.Estado = true;

            // Procesamos la respuesta
            Debug.Log("Respuesta recibida con exito:");
            Debug.Log("Estado: " + loginResponse.Estado);
            Debug.Log("Mensaje: " + loginResponse.Mensaje);
            // Validamos si los datos del usuario son diferentes de nulos para poder mostrarlos sin errores
            if (loginResponse.Datos != null)
            {
                Debug.Log("Identificacion: " + loginResponse.Datos.Identificacion);
                Debug.Log("NombreCompleto: " + loginResponse.Datos.NombreCompleto);
                Debug.Log("TipoDeUsuario: " + loginResponse.Datos.TipoDeUsuario);
                Debug.Log("Programa: " + loginResponse.Datos.Programa);
                Debug.Log("Facultad: " + loginResponse.Datos.Facultad);
            }
        }
    }
}