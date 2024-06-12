using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnColorPersonalizar : MonoBehaviour
{
    public Personalizacion personalizacion;
    public TipoElemento tipo;
    public int indice;
    public bool esPrincipal;

    private void Start()
    {
        GetComponent<UnityEngine.UI.Image>().color = personalizacion.GetColor(tipo, indice);
    }
    public void Activar()
    {
        print("Activo" + tipo.ToString());
        switch (tipo)
        {
            case TipoElemento.maleta:
                //personalizacion.CambiarColorMaleta(indice);
                break;
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
                    personalizacion.CambiarMaterialPiel(indice);
                }
                else
                {
                    personalizacion.CambioColorSecundario(indice);
                    personalizacion.CambiarMaterialPiel(indice);
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
