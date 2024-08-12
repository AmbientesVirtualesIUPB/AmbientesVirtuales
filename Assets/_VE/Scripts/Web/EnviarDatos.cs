using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnviarDatos : MonoBehaviour
{
    public string url = "http://localhost/apiweb/formulario.php"; // Cambia esto a la URL de tu archivo PHP
    public int[] datos = new int[14]; // Tu array de 14 posiciones

    // Llama a este método para enviar los datos
    [ContextMenu("Enviar")]
    public void Enviar()
    {
        StartCoroutine(EnviarDatosCoroutine());
    }

    private IEnumerator EnviarDatosCoroutine()
    {
        WWWForm form = new WWWForm();

        // Añadir cada dato del array al formulario
        for (int i = 0; i < datos.Length; i++)
        {
            form.AddField("dato" + i, datos[i]);
            Debug.Log($"Enviando dato{i}: {datos[i]}"); // Imprime los datos para verificar que se están enviando
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Datos enviados con éxito: " + www.downloadHandler.text);
            }
            else
            {
                Debug.LogError("Error al enviar los datos: " + www.error);
            }
        }
    }
}
