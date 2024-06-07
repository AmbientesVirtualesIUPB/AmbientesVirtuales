using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Exploración/Varios/E Cronometro")]
public class ECronometro : MonoBehaviour
{
	public float intervalo;
	public UnityEvent evento;
	public bool esperaInicial;
	public bool activo = true;

	private void Start()
	{
		if (!esperaInicial)
		{
			Accionar();
		}
		InvokeRepeating("Accionar", intervalo, intervalo);
	}

	public void Activar()
	{
		activo = true;
	}
	public void Desactivar()
	{
		activo = false;
	}

	public void Accionar()
	{
		if (activo)
		{
			evento.Invoke();
		}
	}
}
