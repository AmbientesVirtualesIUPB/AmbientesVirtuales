using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalizadorCombos : MonoBehaviour
{
    public ComboPersonalizable comboCabezas;
    public ComboPersonalizable comboTorsos;
    public ComboPersonalizable comboCabellos;
    public ComboPersonalizable comboPantalon;
    public ComboPersonalizable comboZapatos;
    public Color[] coloresPiel0;
    public Color[] coloresPiel1;
    public Color[] coloresPelo0;
    public Color[] coloresPelo1;
    public Color[] colores0;
    public Color[] colores1;

    int cabezaActual;
    int colorPielActual0;
    int colorPielActual1;

    int cabelloActual;
    int colorCabelloActual0;
    int colorCabelloActual1;

    int torsoActual;
    int colorRopaActual0;
    int colorRopaActual1;

    int pantalonActual;

    int zapatosActual;
    int colorZapatosActual0;
    int colorZapatosActual1;

    void Start()
    {
        ConfigurarCabeza(Random.Range(0, comboCabezas.mallas.Length));
        ConfigurarTorso(Random.Range(0, comboTorsos.mallas.Length));
        ConfigurarCabello(Random.Range(0, comboCabellos.mallas.Length));
        ConfigurarPantalon(Random.Range(0, comboPantalon.mallas.Length));
        ConfigurarZapatos(Random.Range(0, comboZapatos.mallas.Length));

        CambiarColorPiel(Random.Range(0, coloresPiel0.Length), Random.Range(0, coloresPiel1.Length));
        CambiarColorRopa(Random.Range(0, colores0.Length), Random.Range(0, colores1.Length));
        CambiarColorCabellos(Random.Range(0, coloresPelo0.Length), Random.Range(0, coloresPelo1.Length));
    }


    void ConfigurarCabeza(int cual)
    {
        for (int i = 0; i < comboCabezas.mallas.Length; i++)
        {
            comboCabezas.mallas[i].gameObject.SetActive(i == cual);
        }
        cabezaActual = cual;
    }
    void ConfigurarTorso(int cual)
    {
        for (int i = 0; i < comboTorsos.mallas.Length; i++)
        {
            comboTorsos.mallas[i].gameObject.SetActive(i == cual);
        }
        torsoActual = cual;
    }

    void ConfigurarCabello(int cual)
    {
        for (int i = 0; i < comboCabellos.mallas.Length; i++)
        {
            comboCabellos.mallas[i].gameObject.SetActive(i == cual);
        }
        cabelloActual = cual;
    }

    void ConfigurarPantalon(int cual)
    {
        for (int i = 0; i < comboPantalon.mallas.Length; i++)
        {
            comboPantalon.mallas[i].gameObject.SetActive(i == cual);
        }
    }
    void ConfigurarZapatos(int cual)
    {
        for (int i = 0; i < comboZapatos.mallas.Length; i++)
        {
            comboZapatos.mallas[i].gameObject.SetActive(i == cual);
        }
    }

    public void CambiarColorPiel(int nuevo0, int nuevo1)
    {
        comboCabezas.ConfigurarColoresPiel(nuevo0, nuevo1, coloresPiel0, coloresPiel1);
        comboPantalon.ConfigurarColoresPiel(nuevo0, nuevo1, coloresPiel0, coloresPiel1);
        comboTorsos.ConfigurarColoresPiel(nuevo0, nuevo1, coloresPiel0, coloresPiel1);
    }
    public void CambiarColorRopa(int nuevo0, int nuevo1)
    {
        comboTorsos.ConfigurarColoresRopa(nuevo0, nuevo1, colores0, colores1);
        comboPantalon.ConfigurarColoresRopa(nuevo0, nuevo1, colores0, colores1);
    }
    public void CambiarColorZapatos(int nuevo0, int nuevo1)
    {
        comboZapatos.ConfigurarColoresRopa(nuevo0, nuevo1, colores0, colores1);
    }
    public void CambiarColorCabellos(int nuevo0, int nuevo1)
    {
        comboCabellos.ConfigurarColoresPelo(nuevo0, nuevo1, coloresPelo0, coloresPelo1);
    }

    public void SiguienteCabeza()
    {
        cabezaActual = (cabezaActual + 1) % comboCabezas.mallas.Length;
        ConfigurarCabeza(cabezaActual);
    }
    public void AnteriorCabeza()
    {
        cabezaActual = (comboCabezas.mallas.Length + cabezaActual - 1) % comboCabezas.mallas.Length;
        ConfigurarCabeza(cabezaActual);
    }
    public void SiguienteColorPiel(int cual)
    {
		if (cual == 0)
		{
            colorPielActual0 = (colorPielActual0 + 1) % coloresPiel0.Length;
		}
		else
		{
            colorPielActual1 = (colorPielActual1 + 1) % coloresPiel1.Length;
        }
        CambiarColorPiel(colorPielActual0, colorPielActual1);
    }



    /// <summary>
    /// //////////////////////////// Cabellos
    /// </summary>
    public void SiguienteCabello()
    {
        cabelloActual = (cabelloActual + 1) % comboCabellos.mallas.Length;
        ConfigurarCabello(cabelloActual);
    }
    public void AnteriorCabello()
    {
        cabelloActual = (comboCabellos.mallas.Length + cabelloActual - 1) % comboCabellos.mallas.Length;
        ConfigurarCabello(cabelloActual);
    }
    public void SiguienteColorCabello(int cual)
    {
        if (cual == 0)
        {
            colorCabelloActual0 = (colorCabelloActual0 + 1) % coloresPelo0.Length;
        }
        else
        {
            colorCabelloActual1 = (colorCabelloActual1 + 1) % coloresPelo1.Length;
        }
        CambiarColorCabellos(colorCabelloActual0, colorCabelloActual1);
    }


    /// <summary>
    /// //////////////////////////// Torsos
    /// </summary>
    public void SiguienteTorso()
    {
        torsoActual = (torsoActual + 1) % comboTorsos.mallas.Length;
        ConfigurarTorso(torsoActual);
    }
    public void AnteriorTorso()
    {
        torsoActual = (comboTorsos.mallas.Length + torsoActual - 1) % comboTorsos.mallas.Length;
        ConfigurarTorso(torsoActual);
    }
    public void SiguienteColorTorso(int cual)
    {
        if (cual == 0)
        {
            colorRopaActual0 = (colorRopaActual0 + 1) % colores0.Length;
        }
        else
        {
            colorRopaActual1 = (colorRopaActual1 + 1) % colores1.Length;
        }
        CambiarColorRopa(colorRopaActual0, colorRopaActual1);
    }
    /// <summary>
    /// //////////////////////////// Pantalones
    /// </summary>
    public void SiguientePantalon()
    {
        pantalonActual = (pantalonActual + 1) % comboPantalon.mallas.Length;
        ConfigurarPantalon(pantalonActual);
    }
    public void AnteriorPantalon()
    {
        pantalonActual = (comboPantalon.mallas.Length + pantalonActual - 1) % comboPantalon.mallas.Length;
        ConfigurarPantalon(pantalonActual);
    }
    public void SiguienteColorPantalon(int cual)
    {
        if (cual == 0)
        {
            colorRopaActual0 = (colorRopaActual0 + 1) % colores0.Length;
        }
        else
        {
            colorRopaActual1 = (colorRopaActual1 + 1) % colores1.Length;
        }
        CambiarColorRopa(colorRopaActual0, colorRopaActual1);
    }



    /// <summary>
    /// //////////////////////////// Zapatos
    /// </summary>
    public void SiguienteZapato()
    {
        zapatosActual = (zapatosActual + 1) % comboZapatos.mallas.Length;
        ConfigurarZapatos(zapatosActual);
    }
    public void AnteriorZapato()
    {
        zapatosActual = (comboZapatos.mallas.Length + zapatosActual - 1) % comboZapatos.mallas.Length;
        ConfigurarZapatos(zapatosActual);
    }
    public void SiguienteColorZapato(int cual)
    {
        if (cual == 0)
        {
            colorZapatosActual0 = (colorZapatosActual0 + 1) % colores0.Length;
        }
        else
        {
            colorZapatosActual1 = (colorZapatosActual1 + 1) % colores1.Length;
        }
        CambiarColorZapatos(colorZapatosActual0, colorZapatosActual1);
    }
}
