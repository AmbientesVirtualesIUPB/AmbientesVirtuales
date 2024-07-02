using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class envioPHP : MonoBehaviour
{
    public string url = "http://localhost/apiwebm/form.php"; // Asegúrate de que la URL sea correcta
    public float[] pos = new float[14]; // Supón que este es tu array de 14 posiciones

    IEnumerator Start()
    {
        // Inicializa el array con algunos valores para el ejemplo
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = i;
        }

        // Convierte el array a JSON
        string jsonData = JsonUtility.ToJson(new Wrapper<float> { data = pos });
        Debug.Log("JSON Data: " + jsonData); // Imprime el JSON para verificarlo

        WWWForm form = new WWWForm();
        form.AddField("data", jsonData);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text); // Muestra la respuesta del servidor
            }
        }
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] data;
    }
}
