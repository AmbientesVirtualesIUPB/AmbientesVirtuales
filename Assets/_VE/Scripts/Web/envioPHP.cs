using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class envioPHP : MonoBehaviour
{
    public string url = "http://localhost/apiwebm/form_ejemplo.php"; // URL a donde enviaremos los datos
    public float[] pos = new float[14]; // Ejemplo array de 14 posiciones

    IEnumerator Start()
    {
        // Convierte el array a JSON
        string jsonData = JsonUtility.ToJson(new Wrapper<float> { data = pos });
        Debug.Log("JSON Data: " + jsonData); // Imprime el JSON para verificarlo

        // Crea un formulario WWW (formulario HTML) para enviar los datos
        WWWForm form = new WWWForm();
        // Añade el campo "data" con el JSON convertido
        form.AddField("data", jsonData);

        // Realiza una solicitud POST a la URL especificada usando UnityWebRequest
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            // Espera a que la solicitud se complete
            yield return www.SendWebRequest();

            // Verifica si la solicitud fue exitosa
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error); // Imprime el error en caso de fall
            }
            else
            {
                Debug.Log(www.downloadHandler.text); // Muestra la respuesta del servidor
            }
        }
    }

    // Clase genérica que se utiliza para serializar el array a JSON
    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] data;
    }
}
