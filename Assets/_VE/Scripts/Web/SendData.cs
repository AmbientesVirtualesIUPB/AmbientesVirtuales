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
        StartCoroutine(EnviarDatosCoroutine());
    }

    private IEnumerator EnviarDatosCoroutine()
    {
        WWWForm form = new WWWForm();
        for (int i = 0; i < posiciones.Length; i++)
        {
            form.AddField($"pos{i + 1}", posiciones[i]);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Formulario enviado con éxito: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error al enviar el formulario: " + www.error);
            }
        }
    }
}
