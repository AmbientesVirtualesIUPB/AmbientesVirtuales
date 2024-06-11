using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Personalizacion : MonoBehaviour
{
    public ElementoPersonalizable[] partesHombre;
    public ElementoPersonalizable[] partesMujer;
    public ElementoPersonalizable[] partesOtros;
    public int genero;
    public Color[] paletaPiel;
    public Color[] paletaCabello;
    public Color[] paletaOjos;
    public Color[] paletaRopa;
    public Material materialInicialPielHombre;
    public Material materialInicialPielMujer;
    public Material[] materiales;
    int num;


    // Start is called before the first frame update
    void Start()
    {
        InicializarElementos();
        TransicionDeGenero(0);
    }


    // Pasar elemento a elemento las caracteristicas unicamente pertenecientes al genero Masculino
    public void SiguienteParteHombre(int cual)
    {
        partesHombre[cual].Siguiente();
    }

    // Pasar elemento a elemento las caracteristicas unicamente pertenecientes al genero Femenino
    public void SiguienteParteMujer(int cual)
    {
        partesMujer[cual].Siguiente();
    }

    // Pasar elemento a elemento las caracteristicas pertenecientes a ambos generos, invocado desde los botones de personalizacion
    public void SiguienteParteOtro(int cual)
    {
        partesOtros[cual].Siguiente();
    }


    // Metodo invocado desde los botones de personalizacion, enviado el dato correspondiente a la caracteristica a modificar
    public void SiguienteParteGay(int cual)
    {
        if (genero==0)
        {
            SiguienteParteMujer(cual);
        }
        else
        {
            SiguienteParteHombre(cual);
        }
    }

    // Metodo invocado desde BtnMasculino y BtnFemenino para el cambio de genero
    public void TransicionDeGenero(int cual)
    {
        genero = cual;
        // Si es cero, es femenino, establecemos los elementos de dicho genero y desactivamos los masculinos
        // Si es uno, es masculino, establecemos los elementos de dicho genero y desactivamos los femeninos
        if (genero==0)
        {
            for (int i = 0; i < partesHombre.Length; i++)
            {
                partesHombre[i].Desactivar();
                partesMujer[i].Establecer();
            }
        }else
        {
            for (int i = 0; i < partesHombre.Length; i++)
            {
                partesHombre[i].Establecer();
                partesMujer[i].Desactivar();
            }
        }

        // Establecemos los elementos de ambos generos
        for (int i = 0;i < partesOtros.Length; i++)
        {
            partesOtros[i].Establecer();
        }
    }

    public void SiguienteColorPiel()
    {

    }


    // PRUEBA CAMBIO DE MATERIALES
    public void Materiales(int cual)
    {
        for (int i = 0; i < partesHombre.Length; i++)
        {
            //partesHombre[i].EstablecerMaterialPiel(materiales[cual]);
            partesMujer[i].EstablecerMaterialPiel(materiales[cual]);
        }
    }
    public void SiguienteMaterial()
    {
        num = (num + 1) % materiales.Length;
        Materiales(num);
    }


    public void InicializarElementos()
    {
        for (int i = 0; i < partesHombre.Length; i++)
        {
            partesHombre[i].EstablecerMaterialPiel(materialInicialPielHombre);
            partesHombre[i].paleta = paletaPiel;

            partesMujer[i].EstablecerMaterialPiel(materialInicialPielMujer);
            partesMujer[i].paleta = paletaPiel;
        }

        for (int i = 0; i < partesOtros.Length; i++)
        {
            partesOtros[i].paleta = paletaRopa;
        }
    }
}


[System.Serializable]
public class ElementoPersonalizable
{
    public string nombre;
    public Color color1;
    public Color color2;
    int iColor1;
    int iColor2;
    public GameObject[] elementos;
    public int activo;
    public Color[] paleta;
    public Material materialPiel;


    public void Establecer()
    {
        for (int i = 0; i < elementos.Length; i++)
        {
            elementos[i].SetActive(i == activo);
        }
    }
    public void Establecer(int _activo)
    {
        activo = _activo;
        Establecer();
    }


    public void EstablecerMaterialPiel(Material m)
    {
        for (int i = 0;i < elementos.Length;i++) 
        { 
            Renderer mr = elementos[i].GetComponent<Renderer>();
            if (mr != null)
            {
                for (int j = 0; j < mr.materials.Length; j++)
                {
                    if ((mr.materials[j].name).Substring(0,3)=="SKN")
                    {
                        //Debug.Log("Entro SKN" + mr.ToString());
                        Material[] mats = mr.materials;
                        mats[j] = m;
                        mr.materials = mats;
                        materialPiel = mr.materials[j];
                    }
                }
            }
        }
    }

    //
    public void Siguiente()
    {
        activo = (activo+1) % elementos.Length;
        Establecer();
    }

    public void Anterior()
    {
        activo = (activo - 1 + elementos.Length) % elementos.Length;
        Establecer();

    }

    public void Desactivar()
    {
        for (int i = 0; i < elementos.Length; i++)
        {
            elementos[i].SetActive(false);
        }
    }

    public string ConvertirATexto()
    {
        string texto = iColor1 + "-" + iColor2 + "-" + activo;
        
        return texto;
    }

    public void ConvertirDesdeTexto(string texto)
    {
        string[] nombre = texto.Split("-");

        iColor1 =  int.Parse(nombre[0]);
        iColor2 =  int.Parse(nombre[1]);
        activo  =  int.Parse(nombre[2]);
        Establecer();
    }


    public void SiguientePielColor1()
    {
        iColor1 = (iColor1 + 1) % paleta.Length;
        if (materialPiel!=null)
        {
            materialPiel.SetColor("_ColorPrincipal", paleta[iColor1]);
        }
    }

    public void SiguientePielColor2()
    {
        iColor2 = (iColor2 + 1) % paleta.Length;
        if (materialPiel != null)
        {
            materialPiel.SetColor("_ColorSecundario", paleta[iColor2]);
        }
    }

}
