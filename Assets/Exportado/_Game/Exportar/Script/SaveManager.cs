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
        //leemos el archivo Json
        string splitJson = File.ReadAllText(path);
        //Convertimos el archivo Json a objeto unity
        SaveSplit splitLoad = JsonUtility.FromJson<SaveSplit>(splitJson);

        //Asignamos la informacion guardada
        for (int i = 0; i < split.pos.Length; i++)
        {
            split.pos[i] = splitLoad.pos[i];
        }
        Debug.Log(path);
    }


    public void PesonalizacionPersonaje(int numero, int posicion)
    {
        //Dependiento del numero y la posicion, asignamos antes de guardar
        for (int i = 0; i < split.pos.Length; i++)
        {
            //Si la posicion es la indicada, guardamos el dato
            if (i == posicion)
            {
                split.pos[i] = numero;
            }
        }

        //Grabamos
        Save();
    }

    public void CargarDatos()
    {
        //Cargamos
        Load();

        //Asignamos los datos al personaje
        for (int i = 0; i < split.pos.Length; i++)
        {
            personalizacion.gameObject.GetComponent<Split>().pos[i] = split.pos[i];
        }  
    }
}
