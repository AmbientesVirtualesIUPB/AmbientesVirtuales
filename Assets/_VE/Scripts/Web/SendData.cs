using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SendData : MonoBehaviour
{
    public string url = "http://localhost/apiwebm/formulario_ejemplo.php"; // Cambia esto por la URL

    // Ejemplo de array de 9 posiciones
    private string[] posiciones = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    [ContextMenu("Enviar")]
    // Método para enviar los datos
    public void EnviarDatos()
    {
        // Inicia la coroutine que enviará los datos
        StartCoroutine(EnviarDatosCoroutine());
    }

    private IEnumerator EnviarDatosCoroutine()
    {
        // Crea un formulario WWW (formulario HTML) para enviar los datos
        WWWForm form = new WWWForm();
        // Añade cada posición del array al formulario
        for (int i = 0; i < posiciones.Length; i++)
        {
            form.AddField($"pos{i + 1}", posiciones[i]);
        }

        // Realiza una solicitud POST a la URL especificada usando UnityWebRequest
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            // Espera a que la solicitud se complete
            yield return www.SendWebRequest();

            // Verifica si la solicitud fue exitosa
            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Formulario enviado con éxito: " + www.downloadHandler.text); // Imprime la respuesta del servidor en la consola
            }
            else
            {
                Debug.LogError("Error al enviar el formulario: " + www.error); // Imprime el error en caso de fallo
            }
        }
    }
}
