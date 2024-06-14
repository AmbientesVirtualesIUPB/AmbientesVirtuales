using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class SaveSplit
{
    //En esta clase podemos agregar todas las variables que deseemos guardar en formato Json

    //Variable para guardas las posiciones de la personalizacion del personaje
    public int[] pos = new int[13]; 
    

    //Constructor con informacion por defecto
    public SaveSplit()
    {

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = 0;
        }

    }
}
