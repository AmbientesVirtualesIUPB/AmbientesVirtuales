using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personalizador : MonoBehaviour
{
    public GameObject[] cabezas;
    public GameObject[] cuerpos;
    public GameObject[] pelviss;
    public Gradiente colores;

    public List<Material>  materiales;

    int cabeza;
    int cuerpo;
    int pelvis;
    int color1;
    int color2;

    void Start()
    {
        materiales = new List<Material>();
        MeshRenderer[] mrs = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < mrs.Length; i++)
        {
            materiales.Add(mrs[i].material);
        }
        CargarDatos();
        Activar();
    }

    public void Activar()
    {
        for (int i = 0; i < materiales.Count; i++)
        {
            materiales[i].SetColor("_ColorPrincipal", colores.Evaluate(color1));
            materiales[i].SetColor("_ColorSecundario", colores.Evaluate(color2));
        }
        if (cabezas.Length > 0)
        {
            for (int i = 0; i < cabezas.Length; i++)
            {
                cabezas[i].SetActive(i == cabeza);
            }
        }
        if (cuerpos.Length > 0)
        {
            for (int i = 0; i < cuerpos.Length; i++)
            {
                cuerpos[i].SetActive(i == cuerpo);
            }
        }
        if (pelviss.Length > 0)
        {
            for (int i = 0; i < pelviss.Length; i++)
            {
                pelviss[i].SetActive(i == pelvis);
            }
        }
        
    }

    void CargarDatos()
    {
        cabeza = PlayerPrefs.GetInt("cabeza", 0);
        cuerpo = PlayerPrefs.GetInt("cuerpo", 0);
        pelvis = PlayerPrefs.GetInt("pelvis", 0);
        color1 = PlayerPrefs.GetInt("color1", 1);
        color2 = PlayerPrefs.GetInt("color2", 2);
    }

    public void SiguienteCabeza()
    {
        cabeza = (cabeza + 1) % cabezas.Length;
        PlayerPrefs.SetInt("cabeza", cabeza);
        Activar();
    }
    public void SiguienteCuerpo()
    {
        cuerpo = (cuerpo + 1) % cuerpos.Length;
        PlayerPrefs.SetInt("cuerpo", cuerpo);
        Activar();
    }
    public void SiguientePelvis()
    {
        pelvis = (pelvis + 1) % pelviss.Length;
        PlayerPrefs.SetInt("pelvis", pelvis);
        Activar();
    }
    public void SiguienteColor1()
    {
        color1 = (color1 + 1) % 10;
        PlayerPrefs.SetInt("color1", color1);
        Activar();
    }
    public void SiguienteColor2()
    {
        color2 = (color2 + 1) % 10;
        PlayerPrefs.SetInt("color2", color2);
        Activar();
    }

    public void AnteriorCabeza()
    {
        cabeza = (cabeza + cabezas.Length -1) % cabezas.Length;
        PlayerPrefs.SetInt("cabeza", cabeza);
        Activar();
    }
    public void AnteriorCuerpo()
    {
        cuerpo = (cuerpo + cuerpos.Length - 1) % cuerpos.Length;
        PlayerPrefs.SetInt("cuerpo", cuerpo);
        Activar();
    }
    public void AnteriorPelvis()
    {
        pelvis = (pelvis + pelviss.Length - 1) % pelviss.Length;
        PlayerPrefs.SetInt("pelvis", pelvis);
        Activar();
    }
    public void AnteriorColor1()
    {
        color1 = (color1 + 9) % 10;
        PlayerPrefs.SetInt("color1", color1);
        Activar();
    }
    public void AnteriorColor2()
    {
        color2 = (color2 + 9) % 10;
        PlayerPrefs.SetInt("color2", color2);
        Activar();
    }

    public Color GetColor(int cual)
    {
        if (cual == 1)
        {
            return colores.Evaluate(color1);
        }
        return colores.Evaluate(color2);
    }

}

[System.Serializable]
public class Gradiente
{
    public Color[] colores;

    public Color Evaluate(int cual)
    {
        return colores[cual];
    }
}