using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnvioDatosBD : MonoBehaviour
{
    public string url = "http://localhost/apiweb/insertar_datos.php"; // URL de tu archivo PHP
    public int id_usuario; // El id del usuario
    public int[] datos = new int[21]; // Array de datos enteros (genero, maleta, cuerpo, cabeza, cejas, cabello, reloj, sombrero, zapatos, tamaño, color1, color2, color3, color4, color5, carroceria, aleron, silla, volante, llanta, bateria)

    IEnumerator Start()
    {
        // Creación del formulario
        WWWForm form = new WWWForm();
        form.AddField("id_usuario", id_usuario);

        // Asegúrate de que el array de datos tenga el tamaño correcto
        if (datos.Length != 21)
        {
            Debug.LogError("El array de datos debe tener exactamente 21 elementos.");
            yield break; // Detiene la ejecución si el tamaño del array no es el correcto
        }

        // Añadir los datos al formulario
        for (int i = 0; i < datos.Length; i++)
        {
            form.AddField($"dato{i}", datos[i]);
        }

        // Enviar la solicitud POST
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Datos enviados con éxito.");
            }
            else
            {
                Debug.LogError("Error al enviar los datos: " + www.error);
            }
        }
    }
}
