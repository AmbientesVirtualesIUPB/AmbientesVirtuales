using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GestionTurnos : MonoBehaviour
{
    public TextMeshProUGUI txtTurno;

    public Image imManoTurno;
    public Color colorNormal;
    public Color colorTurno;
    public int turnoActual;
    public int turnosPedidos;


    public static GestionTurnos singleton;

	private void Awake()
	{
        singleton = this;
	}

    public void ActualizarTurnosPedidos(int numero)
	{
        turnosPedidos = numero;
        imManoTurno.color = colorNormal;
	}

    public void SiguienteTurno()
	{
        if(turnoActual < turnosPedidos) turnoActual++;
        txtTurno.text = "Turno: " + turnoActual;
		if (turnoActual == turnosPedidos)
		{
            imManoTurno.color = colorTurno;
		}
	}

    public void TerminarAtencion()
	{
        SelectorTurnos.singleton.gmTurnoMano.SetActive(false);
	}

}
