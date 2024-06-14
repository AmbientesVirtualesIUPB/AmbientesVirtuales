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
    public Color[] paletaCejas;
    public Color[] paletaCabello;
    public Color[] paletaOjos;
    public Color[] paletaRopa;
    public Color[] paletaPiel;
    public Material materialInicialPielHombre;
    public Material materialInicialPielMujer;
    public Material[] matPielMujer;
    public Material[] matPielHombre;
    int numMaterial;
    //
    List<Material> materialesGenerales = new List<Material>(10);


    // Start is called before the first frame update
    void Start()
    {
        InicializarElementos();
        TransicionDeGenero(0);

    }

    [ContextMenu("Pintar")]
    public void ColorRandom()
    {
        //partesMujer[4].materialGeneral.color = Color.red;
    }

    public void InicializarListasMateriales()
    {
        /*
        for (int i = 0; i < partesHombre.elementos.Length; i++)
        {
            Renderer mr = elementos[i].GetComponent<Renderer>();
            Debug.Log(mr.materials[i].name);
            if (mr != null)
            {
                Material[] materia = mr.materials;

                if (materia[i] != null)
                {
                    materialesGenerales.Add(materia[i]);
                    Debug.Log("materialesGenerales.ToString()");
                }
            }
            for (int j = 0; j < materialesGenerales.Count; j++)
            {
                //materialPiel.Add(mr.materials[j]);
            }
        }*/
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


    // PRUEBA CAMBIO DE MATERIALES
    public void CambiarMaterialPiel(int cual)
    {
        for (int i = 0; i < partesHombre.Length; i++)
        {
            //partesHombre[i].EstablecerMaterialPiel(matPielHombre[cual]);
<<<<<<< Updated upstream
            partesMujer[i].EstablecerMaterialPiel(cual);
=======
            partesMujer[i].EstablecerMaterialPiel(matPielMujer[cual]);
>>>>>>> Stashed changes
        }
    }
    public void SiguienteMaterialPiel()
    {
        numMaterial = (numMaterial + 1) % matPielMujer.Length;
<<<<<<< Updated upstream
        CambiarMaterialPiel(numMaterial);
=======
        CambiarMaterialPïel(numMaterial);
>>>>>>> Stashed changes
    }

    public void CambioColorPrincipal(int num)
    {
        print("Cambio color principal" + num.ToString());

        for (int i = 0; i < partesHombre.Length; i++)
        {
            partesHombre[i].EstablecerColorPrincipal(num);
            partesMujer[i].EstablecerColorPrincipal(num);
        }

        for (int i = 0; i < partesOtros.Length; i++)
        {
            partesOtros[i].EstablecerColorPrincipal(num);
        }
    }

    public void CambioColorSecundario(int num)
    {
        for (int i = 0; i < partesHombre.Length; i++)
        {
            partesHombre[i].EstablecerColorSecundario(num);
            partesMujer[i].EstablecerColorSecundario(num);
        }

        for (int i = 0; i < partesOtros.Length; i++)
        {
            partesOtros[i].EstablecerColorSecundario(num);
        }
    }

    public void CambiarColorCabello(int num)
    {
        print("Cambio color cabello " + num.ToString());
<<<<<<< Updated upstream
        partesHombre[4].EstablecerColorGeneral(num);
        partesHombre[3].EstablecerColorGeneral(num);
        partesMujer[4].EstablecerColorGeneral(num);
        partesMujer[3].EstablecerColorGeneral(num);
=======
        partesHombre[4].EstablecerColorGeneralPrueba(num);
        partesHombre[3].EstablecerColorGeneralPrueba(num);
        partesMujer[4].EstablecerColorGeneralPrueba(num);
        partesMujer[3].EstablecerColorGeneralPrueba(num);
>>>>>>> Stashed changes
    }

    public void CambiarColorOjos(int num)
    {
        print("Cambio color ojos " + num.ToString());
<<<<<<< Updated upstream
        partesOtros[3].EstablecerColorGeneral(num);
=======
        partesOtros[3].EstablecerColorGeneralPrueba(num);
>>>>>>> Stashed changes
    }

    public void CambiarColorMaleta(int num)
    {
        print("Cambio color Maleta " + num.ToString());
        partesHombre[0].EstablecerColorGeneral(num);
        partesMujer[4].EstablecerColorGeneral(num);
    }


    public void InicializarElementos()
    {
        for (int i = 0; i < partesHombre.Length; i++)
        {
            partesHombre[i].Inicializar();
            partesHombre[i].padre = this;
            partesHombre[i].EstablecerMaterialPiel(0);
            partesHombre[i].EstablecerColorPrincipal(0);
            partesHombre[i].EstablecerColorSecundario(0);

            partesMujer[i].Inicializar();
            partesMujer[i].padre = this;
            partesMujer[i].EstablecerMaterialPiel(0);
            partesMujer[i].EstablecerColorPrincipal(0);
            partesMujer[i].EstablecerColorSecundario(0);

        }

        for (int i = 0; i < partesOtros.Length; i++)
        {
            partesOtros[i].padre = this;
            partesOtros[i].Inicializar();
        }
    }


    public Color GetColor(TipoElemento t, int i)
    {
        switch (t)
        {
            case TipoElemento.maleta:
                return paletaCejas[i];
            case TipoElemento.cabello:
                return paletaCabello[i];
            case TipoElemento.ojos:
                return paletaOjos[i];
            case TipoElemento.cejas:
                return paletaCabello[i];
            case TipoElemento.ropa:
                return paletaRopa[i];
            case TipoElemento.piel:
                return paletaPiel[i];
            default:
                return paletaRopa[i];
        }
    }
    public Color GetColorPiel(int i)
    {
        return paletaPiel[i];
    }

    public Color[] GetPaleta(TipoElemento t)
    {
        switch (t)
        {
            case TipoElemento.maleta:
                return paletaCejas;
            case TipoElemento.cabello:
                return paletaCabello;
            case TipoElemento.ojos:
                return paletaOjos;
            case TipoElemento.cejas:
                return paletaCabello;
            case TipoElemento.ropa:
                return paletaRopa;
            case TipoElemento.piel:
                return paletaPiel;
            default:
                return paletaRopa;
        }
    }
}


[System.Serializable]
public class ElementoPersonalizable
{
    public string           nombre;
    public TipoElemento     tipo;
    public Personalizacion  padre;
    public GameObject[]     elementos;
    public int              activo;
    public List<Material>   materialesPiel;
    public List<Material>   materialesGenerales;
    //List<Material> materialPiel = new List<Material>();
    
    int iColor1;
    int iColor2;
<<<<<<< Updated upstream
=======
    public GameObject[] elementos;
    public int activo;
    public Material materialPiel;
    public Material materialGeneral;
    //List<Material> materialPiel = new List<Material>();
    
>>>>>>> Stashed changes

    

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

<<<<<<< Updated upstream
    public void Inicializar()
	{
        materialesPiel = new List<Material>();
        materialesGenerales = new List<Material>();
        Renderer mr;
		for (int i = 0; i < elementos.Length; i++)
		{
            mr = elementos[i].GetComponent<Renderer>();
			if (mr != null)
			{
=======
    
    
    

    public void EstablecerMaterialPiel(Material m)
    {
        for (int i = 0;i < elementos.Length;i++) 
        { 
            Renderer mr = elementos[i].GetComponent<Renderer>();
            if (mr != null)
            {
>>>>>>> Stashed changes
                for (int j = 0; j < mr.materials.Length; j++)
                {
                    if (mr.materials[j].name.Substring(0, 3).Equals("SKN"))
                    {
<<<<<<< Updated upstream
                        materialesPiel.Add(mr.materials[j]);
=======
                        Material[] mats = mr.materials;
                        mats[j] = m;
                        mr.materials = mats;
                        materialPiel = mr.materials[j];
>>>>>>> Stashed changes
                    }
                    else
                    {
                        materialesGenerales.Add(mr.materials[j]);
                    }
                }
            }
		}
	}
    
    

    public void EstablecerMaterialPiel(int num)
    {
        iColor1 = num;
        for (int i = 0; i < materialesPiel.Count; i++)
        {
            materialesPiel[i].SetColor("_ColorPrincipal", padre.GetColor(tipo, iColor1));
            Debug.Log("Cambiando el color según el tipo: " + tipo.ToString());
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


    public void SiguienteColorPrincipal()
    {
<<<<<<< Updated upstream
        EstablecerColorPrincipal((iColor1 + 1) % padre.GetPaleta(tipo).Length);
=======
        iColor1 = (iColor1 + 1) % padre.GetPaleta(tipo).Length;
        if (materialGeneral!=null)
        {
            /*
            for (int i = 0; i < materialGeneral.Count; i++)
            {
                materialGeneral[i].SetColor("_ColorPrincipal", padre.GetColor(tipo, iColor1));
            }
            */
            materialGeneral.SetColor("_ColorPrincipal", padre.GetColor(tipo,iColor1));
        }
>>>>>>> Stashed changes
    }

    public void SiguienteColorSecundario()
    {
<<<<<<< Updated upstream
        EstablecerColorSecundario((iColor2 + 1) % padre.GetPaleta(tipo).Length);

=======
        iColor2 = (iColor2 + 1) % padre.GetPaleta(tipo).Length;
        if (materialGeneral != null)
        {
            /*
            for (int i = 0; i < materialGeneral.Count; i++)
            {
                materialGeneral[i].SetColor("_ColorSecundario", padre.GetColor(tipo, iColor2));
            }
            */
            materialGeneral.SetColor("_ColorSecundario", padre.GetColor(tipo,iColor2));
        }
>>>>>>> Stashed changes
    }

    public void EstablecerColorPrincipal(int num)
    {
        iColor1 = num;
<<<<<<< Updated upstream
		for (int i = 0; i < materialesGenerales.Count; i++)
		{
            materialesGenerales[i].SetColor("_ColorPrincipal", padre.GetColor(tipo, iColor1));
=======
        if (materialGeneral != null)
        {
            for (int i = 0; i < elementos.Length; i++)
            {
                Renderer mr = elementos[i].GetComponent<Renderer>();
                if (mr != null)
                {
                    for (int j = 0; j < mr.materials.Length; j++)
                    {
                        if (!((mr.materials[j].name).Substring(0, 3) == "SKN"))
                        {
                            //Debug.Log(mr.materials[j].name);
                            Material[] mats = mr.materials;
                            mats[j].SetColor("_ColorPrincipal", padre.GetColor(tipo, iColor1));
                            mr.materials = mats;

                        }
                    }
                }
            }
>>>>>>> Stashed changes
        }


    }

    public void EstablecerColorSecundario(int num)
    {
        iColor2 = num;
        for (int i = 0; i < materialesGenerales.Count; i++)
        {
<<<<<<< Updated upstream
            materialesGenerales[i].SetColor("_ColorSecundario", padre.GetColor(tipo, iColor2));
        }
    }

    public void EstablecerColorPiel(int num)
    {
        iColor2 = num;
        for (int i = 0; i < materialesPiel.Count; i++)
        {
            materialesPiel[i].SetColor("_ColorPrincipal", padre.GetColorPiel(iColor2));
=======
            for (int i = 0; i < elementos.Length; i++)
            {
                Renderer mr = elementos[i].GetComponent<Renderer>();
                if (mr != null)
                {
                    for (int j = 0; j < mr.materials.Length; j++)
                    {
                        if (!((mr.materials[j].name).Substring(0, 3) == "SKN"))
                        { 
                            Material[] mats = mr.materials;
                            mats[j].SetColor("_ColorSecundario", padre.GetColor(tipo, iColor2));
                            mr.materials = mats;
                        }
                    }
                }
            }
>>>>>>> Stashed changes
        }
    }

    public void EstablecerColorGeneral(int num)
    {
        iColor1 = num;
        for (int i = 0; i < materialesGenerales.Count; i++)
        {
            materialesGenerales[i].color =  padre.GetColor(tipo, iColor1);
        }
        
    }

    public void EstablecerColorGeneralPrueba(int num)
    {
        iColor1 = num;
        if (true)
        {
            for (int i = 0; i < elementos.Length; i++)
            {
                Renderer mr = elementos[i].GetComponent<Renderer>();
                if (mr != null)
                {
                    for (int j = 0; j < mr.materials.Length; j++)
                    {
                        if (!((mr.materials[j].name).Substring(0, 3) == "SKN"))
                        {
                            Material[] mats = mr.materials;
                            mats[j].color = padre.GetColor(tipo, iColor1);
                            materialGeneral = mats[j];
                        }
                    }
                }
            }
        }
    }


}


public enum TipoElemento
{
    maleta,
    cabello,
    ojos,
    cejas,
    ropa,
    piel
}