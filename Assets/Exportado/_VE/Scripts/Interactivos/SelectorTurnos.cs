using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectorTurnos : MonoBehaviour
{
    public int turnoActual = 0;
    public TextMeshProUGUI txtTurno;
    public TextMeshProUGUI txtTurnoMano;
    public Animator animator;
    public GameObject gmTurnoMano;

    float tiempoTurno;
    public static SelectorTurnos singleton;

	private void Awake()
	{
        singleton = this;
	}
	public void SolicitarTurno()
	{
        if (tiempoTurno > Time.time) return;
        turnoActual++;
        txtTurno.text = turnoActual.ToString();
        txtTurnoMano.text = turnoActual.ToString();
        animator.SetTrigger("mostrar");
        tiempoTurno = Time.time + 5;
        GestionTurnos.singleton.ActualizarTurnosPedidos(turnoActual);
        gmTurnoMano.SetActive(true);
	}
}
