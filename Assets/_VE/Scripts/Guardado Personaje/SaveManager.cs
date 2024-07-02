using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    //Objeto con la informacion de BASE_DEFINITIVA
    public GameObject personalizacion;

    //Referenciamos el archivo donde guardaremos la informacion
    [SerializeField]
    private SaveSplit split;

    [ContextMenu("Save")]
    public void Save()
    {
        //Conovertimos el objeto a formato Json
        string splitJson = JsonUtility.ToJson(split);
        //Generamos una ubicacion en disco, persistente para que funcione en cualquier plataforma
        string path = Path.Combine(Application.persistentDataPath, "splitData.data");
        //Guardamos el archibo json
        File.WriteAllText(path, splitJson);
        
    }

    [ContextMenu("Load")]
    public void Load()
    {
        //Traemos la ruta del archivo
        string path = Path.Combine(Application.persistentDataPath, "splitData.data");
        //Validamos si ya existe un archivo de guardado actual
        if (File.Exists(path))
        {
            //leemos el archivo Json
            string splitJson = File.ReadAllText(path);
            //Convertimos el archivo Json a objeto unity
            SaveSplit splitLoad = JsonUtility.FromJson<SaveSplit>(splitJson);

            //Asignamos la informacion guardada
            split.posiciones = splitLoad.posiciones;
        }
        // Sino existe creamos uno por defecto
        else
        {
            Save();
        }
    }

    /// <summary>
    /// Metodo invocado desde el scrip de personalización, para grabar los datos de las posiciones
    /// </summary>
    /// <param name="texto"> Parametro de texto con las posiciones </param>
    public void PesonalizacionPersonaje(string texto)
    {
        split.posiciones = texto;
        //Grabamos
        Save();
    }

    /// <summary>
    /// Metodo invocado desde el script de personalización, en el Awake
    /// </summary>
    public void CargarDatos()
    {
        //Cargamos
        Load();

        //Asignamos los datos al personaje
        personalizacion.gameObject.GetComponent<Personalizacion>().ConvertirDesdeTexto(split.posiciones);
    }
}
