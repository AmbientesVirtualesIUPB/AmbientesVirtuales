using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[AddComponentMenu("Exploración/UI/E Preguntas")]
public class Epreguntas : MonoBehaviour
{

	[Header("Configuración")]
	public bool verConfiguracion;
	[ConditionalHide("verConfiguracion", true)]
	public Text txtPregunta;
	[ConditionalHide("verConfiguracion", true)]
	public Text txtRespuestaA;
	[ConditionalHide("verConfiguracion", true)]
	public Text txtRespuestaB;
	[ConditionalHide("verConfiguracion", true)]
	public Text txtRespuestaC;
	[ConditionalHide("verConfiguracion", true)]
	public Text txtRespuestaD;
	[Header("Preguntas")]
	public Pregunta[] preguntas;
	[Header("Acciones")]
	public UnityEvent acierta;
	public UnityEvent falla;
	private int indice = 0;

	public void PreguntaAleatoria()
	{
		if(preguntas.Length <= 0)
		{
			Debug.Log("No hay preguntas");
			return;
		}
		indice = Random.Range(0, preguntas.Length);
		MostrarPregunta();
	}

	public void PreguntaSiguiente()
	{
		if (preguntas.Length <= 0)
		{
			Debug.Log("No hay preguntas");
			return;
		}
		indice = (indice +1) % preguntas.Length;
		MostrarPregunta();
	}

	public void PreguntaEspecifica(int cual)
	{
		if (preguntas.Length <= 0)
		{
			Debug.Log("No hay preguntas");
			return;
		}
		if (preguntas.Length >= cual || cual <0)
		{
			Debug.Log("No existe una pregunta numerada como: " + cual);
			return;
		}
		indice = cual;
		MostrarPregunta();
	}

	public void MostrarPregunta()
	{
		txtPregunta.text = preguntas[indice].pregunta;
		txtRespuestaA.text = preguntas[indice].opcionA;
		txtRespuestaB.text = preguntas[indice].opcionB;
		txtRespuestaC.text = preguntas[indice].opcionC;
		txtRespuestaD.text = preguntas[indice].opcionD;
		gameObject.SetActive(true);
	}

	public void RevizarRespuesta(int cual)
	{
		bool correcto = false;
		switch (cual)
		{
			case 0:
				correcto = preguntas[indice].respuestaCorrecta == OpcionRespuesta.A;
				break;
			case 1:
				correcto = preguntas[indice].respuestaCorrecta == OpcionRespuesta.B;
				break;
			case 2:
				correcto = preguntas[indice].respuestaCorrecta == OpcionRespuesta.C;
				break;
			case 3:
				correcto = preguntas[indice].respuestaCorrecta == OpcionRespuesta.D;
				break;
			default:
				break;
		}
		if (correcto)
		{
			acierta.Invoke();
		}
		else
		{
			falla.Invoke();
		}
		gameObject.SetActive(false);
	}
}
[System.Serializable]
public class Pregunta
{
	public string pregunta;
	public string opcionA;
	public string opcionB;
	public string opcionC;
	public string opcionD;

	public OpcionRespuesta respuestaCorrecta;
}

public enum OpcionRespuesta
{
	A = 0,
	B = 1,
	C = 2,
	D = 3
}