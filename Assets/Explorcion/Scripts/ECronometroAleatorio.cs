using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Exploración/Varios/E Cronometro Aleatorio")]
public class ECronometroAleatorio : MonoBehaviour
{
	public Vector2 intervalo;
	public UnityEvent evento;
	public bool activo = true;

	void Start()
	{
		StartCoroutine(Tiempo());
	}

	public void Activar()
	{
		activo = true;
	}
	public void Desactivar()
	{
		activo = false;
	}
	
    IEnumerator Tiempo()
    {
		yield return new WaitForSeconds(Random.Range(intervalo.x, intervalo.y));
		if (activo)
		{
			evento.Invoke();
		}
		StartCoroutine(Tiempo());
    }
}
