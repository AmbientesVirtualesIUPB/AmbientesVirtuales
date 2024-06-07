using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonalizacionTemporal : MonoBehaviour
{
    public GameObject[] cuerpos;

    int cuerpoActual;
    int color1;
    int color2;

    public Gradiente colores;
    public List<Material> materiales;
    public Image imColor1;
    public Image imColor2;

    void Start()
    {
        cuerpoActual = -1;
        color1 = PlayerPrefs.GetInt("color1", 1);
        color2 = PlayerPrefs.GetInt("color2", 2);
        CambiarCuerpo();
        AplicarColores();
    }

    [ContextMenu("Cambiar Cuerpo")]
    public void CambiarCuerpo()
	{
        cuerpoActual = (cuerpoActual + 1) % cuerpos.Length;
		for (int i = 0; i < cuerpos.Length; i++)
		{
            cuerpos[i].SetActive(i == cuerpoActual);
		}
	}

    [ContextMenu("Cambiar color 1")]
    public void SiguienteColor1()
    {
        color1 = (color1 + 1) % 10;
        PlayerPrefs.SetInt("color1", color1);
        AplicarColores();
    }
    [ContextMenu("Cambiar color 2")]
    public void SiguienteColor2()
    {
        color2 = (color2 + 1) % 10;
        PlayerPrefs.SetInt("color2", color2);
        AplicarColores();
    }

    [ContextMenu("Anterior color 1")]
    public void AnteriorColor1()
    {
        color1 = (color1 + 9) % 10;
        PlayerPrefs.SetInt("color1", color1);
        AplicarColores();
    }
    [ContextMenu("Anterior color 2")]
    public void AnteriorColor2()
    {
        color2 = (color2 + 9) % 10;
        PlayerPrefs.SetInt("color2", color2);
        AplicarColores();
    }
    public void AplicarColores()
    {
        for (int i = 0; i < materiales.Count; i++)
        {
            materiales[i].SetColor("_ColorPrincipal", colores.Evaluate(color1));
            materiales[i].SetColor("_ColorSecundario", colores.Evaluate(color2));
            imColor2.color = colores.Evaluate(color2);
            imColor1.color = colores.Evaluate(color1);
        }

    }
}
