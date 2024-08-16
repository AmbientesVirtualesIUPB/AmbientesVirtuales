using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;


/// <summary>
/// Utilizada para consumir una API, en este caso la api de SICAU para validar los usuarios activos en el periodo
/// </summary>
public class ConsumirAPI : MonoBehaviour
{
    // Solicitamos una referencia a los InputField del login
    public TMP_InputField       inputUsuario;
    public TMP_InputField       inputPassword;

    // Variable para almacenar los datos del usuario
    public GameObject           managerBD;

    // Establecemos las variables, con los datos de la url a consumir y su llave de autenticacion
    private string              apiUrl = "https://sicau.pascualbravo.edu.co/SICAU/API/ServicioLogin/LoginAmbientesVirtuales";
    private string              apiKey = "s1c4uc0ntr0ld34cc3s02019*";

    /// <summary>
    /// Metodo invocado desde el bot�n Iniciar en el Login para consumir el servicio
    /// </summary>
    public void Consumir()
    {
        //GraficsConfig.configuracionDefault.Equals("true");
        // Crear un objeto con los datos que queremos enviar
        SolicitudLogin solicitudLogin = new SolicitudLogin
        {    
            Email = inputUsuario.text + "@pascualbravo.edu.co",
            Contrase�a = inputPassword.text
        };

        // Convertir el objeto a JSON
        string jsonDato = JsonUtility.ToJson(solicitudLogin);

        // Iniciar la corrutina para enviar los datos
        StartCoroutine(PostData(jsonDato));
    }

    /// <summary>
    /// Currutina empleada para consumir el serevicio donde se valida su recepci�n y posterior lectura
    /// </summary>
    /// <param name="jsonDato"> Objeto convertido en json para su manejo </param>
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
            // Pasamos el json a un objeto tipo LoginRespuesta
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
                string[] datos = new string[5];
                datos[0] = "Identificacion: " + loginResponse.Datos.Identificacion;
                datos[1] = "NombreCompleto: " + loginResponse.Datos.NombreCompleto;
                datos[2] = "TipoDeUsuario: " + loginResponse.Datos.TipoDeUsuario;
                datos[3] = "Programa: " + loginResponse.Datos.Programa;
                datos[4] = "Facultad: " + loginResponse.Datos.Facultad;

                for (int i = 0; i < datos.Length; i++)
                {
                    Debug.Log(datos[i]);
                }
            }

            // Validamos que los datos sean correctos para guardar los datos de usuario
            if (loginResponse.Mensaje != "El usuario y/o contrase�a son inv�lidos")
            {
                // Guardamos la identificacion del usuario convertida a entero
                managerBD.gameObject.GetComponent<EnvioDatosBD>().id_usuario = int.Parse(loginResponse.Datos.Identificacion);

                // Guardamos el tipo de usuario, antes validando que tipo es para darle un valor
                if (loginResponse.Datos.TipoDeUsuario == "Estudiante")
                {
                    managerBD.gameObject.GetComponent<EnvioDatosBD>().tipo_usuario = 2;
                }
                else if (loginResponse.Datos.TipoDeUsuario == "Docente")
                {
                    managerBD.gameObject.GetComponent<EnvioDatosBD>().tipo_usuario = 1;
                }
                else
                {
                    managerBD.gameObject.GetComponent<EnvioDatosBD>().tipo_usuario = 0;
                }
                // Guardamos los datos en la BD para la creacion del usuario
                managerBD.gameObject.GetComponent<EnvioDatosBD>().EnviarDatosU();
                // Cambiamos la escena
                managerBD.gameObject.GetComponent<EnvioDatosBD>().CambioScena();
            }
        }
    }
}

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
    public bool Estado;
    public string Mensaje;
    public DatosRespuesta Datos;
}