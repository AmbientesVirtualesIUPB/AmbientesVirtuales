using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnColorPersonalizar : MonoBehaviour
{
    //Variables para manejar cada boton de color personalizable y su identificación
    public Personalizacion  personalizacion;
    public TipoElemento     tipo;
    public int              indice;
    public bool             esPrincipal;

    private void Start()
    {
        //Obtenemos una referencia del color, para asignarla al boton y darle visualización al usuario
        GetComponent<UnityEngine.UI.Image>().color = personalizacion.GetColor(tipo, indice);
    }

    /// <summary>
    /// Metodo invocado desde cada instancia de los botones en las paletas de colores
    /// </summary>
    public void Activar()
    {
        print("Activo" + tipo.ToString());
        switch (tipo)
        {
            case TipoElemento.cabello:
                personalizacion.CambiarColorCabello(indice);
                break;
            case TipoElemento.ojos:
                personalizacion.CambiarColorOjos(indice);
                break;
            case TipoElemento.cejas:
                personalizacion.CambiarColorCabello(indice);
                break;
            case TipoElemento.ropa:
                if (esPrincipal)
                {
                    personalizacion.CambioColorPrincipal(indice);
                }
                else
                {
                    personalizacion.CambioColorSecundario(indice);
                }
                break;
            case TipoElemento.piel:
                personalizacion.CambiarMaterialPiel(indice);
                break;
            default:
                break;
        }
    }

}
