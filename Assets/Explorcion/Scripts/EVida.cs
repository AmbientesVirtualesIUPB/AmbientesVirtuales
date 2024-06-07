using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[AddComponentMenu("Exploración/Personajes/E Vida")]
public class EVida : MonoBehaviour
{
    public float vidaInicial = 100;
    public float vidaActual;
	public Slider sliderVida;
	public UnityEvent eventoMorir;

	private void Start()
	{
		vidaActual = vidaInicial;
		if (sliderVida != null)
		{
			sliderVida.maxValue = vidaInicial;
			sliderVida.minValue = 0;
			ActualizarSlider();
		}
	}

	public void SumarVida(float cuanto)
	{
		vidaActual += cuanto;
		vidaActual = Mathf.Clamp(vidaActual, 0, vidaInicial);
	}

	public void RestarVida(float cuanto)
	{
		vidaActual -= cuanto;
		vidaActual = Mathf.Clamp(vidaActual, 0, vidaInicial);
		if(vidaActual == 0)
		{
			eventoMorir.Invoke();
			enabled = false;
		}
	}

	public void ActualizarSlider()
	{
		if (sliderVida!=null)
		{
			sliderVida.value = vidaActual;
		}
	}
}
