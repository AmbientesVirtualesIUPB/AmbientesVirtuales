using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class SaveSplit
{
    //En esta clase podemos agregar todas las variables que deseemos guardar en formato Json

    //Variable para guardas las posiciones de la personalizacion del personaje
    public string posiciones;
    

    //Constructor con informacion por defecto
    public SaveSplit()
    {
        posiciones = "";
    }
}
