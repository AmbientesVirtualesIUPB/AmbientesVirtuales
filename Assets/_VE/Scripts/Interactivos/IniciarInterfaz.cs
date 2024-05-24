using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IniciarInterfaz : MonoBehaviour
{
    //Referencia a la interfaz que se desea activar
    public GameObject interfaz;


    //Evento invocado al momento de hacer click con el mouse
    private void OnMouseDown()
    {
        //Activamos el objeto
        interfaz.SetActive(true);
    }

}
