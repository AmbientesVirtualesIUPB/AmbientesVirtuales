using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPersonalizador : MonoBehaviour
{
    public Personalizador personalizador;
    public Image imColores;
    public int indice;

    private void Start()
    {
        Invoke("Inicializar", 0.2f);
    }

    void Inicializar()
    {
        imColores.color = personalizador.GetColor(indice);
    }

    public void SiguienteColor()
    {
        if (indice == 1)
        {
            personalizador.SiguienteColor1();
        }
        else
        {
            personalizador.SiguienteColor2();
        }
        Inicializar();
    }
    public void AnteriorColor()
    {
        if (indice == 1)
        {
            personalizador.AnteriorColor1();
        }
        else
        {
            personalizador.AnteriorColor2();
        }
        Inicializar();
    }
}
