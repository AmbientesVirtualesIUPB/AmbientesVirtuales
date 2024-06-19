using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ConsumirAPI : MonoBehaviour
{
    [Serializable]
    //Representa los datos que enviarás en la solicitud POST
    public class RequestData
    {
        public string key1;
        public string key2;
    }

    [Serializable]
    //Representa los datos que recibirás en la respuesta.
    public class ResponseData
    {
        public string field1;
        public string field2;
        public string field3;
        public string field4;
        public string field5;
    }

    private string apiUrl = "https://sicau.pascualbravo.edu.co/SICAU/API/ServicioLogin/LoginAmbientesVirtuales";  // URL a consumir
    private string apiKey = "Authorization";  // Clave de API
    private string apiValue = "s1c4uc0ntr0ld34cc3s02019*";  // Value secreta

    void Start()
    {
        // Crear un objeto con los datos que queremos enviar
        RequestData requestData = new RequestData
        {
            key1 = "julian.molina834@pascualbravo.edu.co",
            key2 = "Miamolina.2015"
        };

        // Convertir el objeto a JSON
        string jsonData = JsonUtility.ToJson(requestData);

        // Iniciar la corrutina para enviar los datos
        StartCoroutine(PostData(jsonData));
    }

    IEnumerator PostData(string jsonData)
    {
        // Crear una solicitud POST
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");

        // Convertir el JSON a bytes y adjuntar a la solicitud
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonData);
        // Adjunta los datos JSON al cuerpo de la solicitud
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        // Recibe la respuesta en el buffer.
        request.downloadHandler = new DownloadHandlerBuffer();

        // Establecer las cabeceras adecuadas para JSON y autenticación
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Key", apiKey);
        request.SetRequestHeader("Value", apiValue);

        // Enviar la solicitud y esperar la respuesta
        yield return request.SendWebRequest();

        // Comprobar si hay errores en la solicitud
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
            Debug.LogError("Response Code: " + request.responseCode);
            Debug.LogError("URL: " + request.url);
        }
        else
        {
            // Obtener la respuesta en formato JSON
            string jsonResponse = request.downloadHandler.text;
            ResponseData responseData = JsonUtility.FromJson<ResponseData>(jsonResponse);

            // Procesar la respuesta
            Debug.Log("Received response: ");
            Debug.Log("field1: " + responseData.field1);
            Debug.Log("field2: " + responseData.field2);
            Debug.Log("field3: " + responseData.field3);
            Debug.Log("field4: " + responseData.field4);
            Debug.Log("field5: " + responseData.field5);
        }
    }
}