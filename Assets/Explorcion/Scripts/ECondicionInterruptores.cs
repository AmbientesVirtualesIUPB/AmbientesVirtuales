using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[AddComponentMenu("Exploración/Condicionales/E Condicion Interruptores")]
public class ECondicionInterruptores : MonoBehaviour
{
	public EInterruptores interruptores;
	public int cualEvaluar;

	[Header("Ejecuciones automáticas")]
	public bool ejecutarAutomaticamente;
	[ConditionalHide("ejecutarAutomaticamente", true)]
	public bool alIniciar;
	[ConditionalHide("ejecutarAutomaticamente", true)]
	public bool cadaFrame;
	[ConditionalHide("ejecutarAutomaticamente", true)]
	public bool cronometricamente;
	[ConditionalHide("cronometricamente", true)]
	public float tiempoCronometro;
	[Header("Acciones a Desarrollar")]
	public UnityEvent siSeCumple;
	public UnityEvent noSeCumple;

	void Start()
    {
		if (alIniciar && ejecutarAutomaticamente)
		{
			Evaluar();
		}
		if (cronometricamente && ejecutarAutomaticamente)
		{
			StartCoroutine(Cronometro());
		}
	}

	public IEnumerator Cronometro()
	{
		Evaluar();
		yield return new WaitForSeconds(tiempoCronometro);
		StartCoroutine(Cronometro());
	}
	
	void Update()
	{
		if (cadaFrame && ejecutarAutomaticamente)
		{
			Evaluar();
		}
	}

	public void Evaluar()
	{
		if (interruptores.LeerInterruptor(cualEvaluar))
		{
			siSeCumple.Invoke();
		}
		else
		{
			noSeCumple.Invoke();
		}
	}

	public void Evaluar(int cual)
	{
		if (interruptores.LeerInterruptor(cual))
		{
			siSeCumple.Invoke();
		}
		else
		{
			noSeCumple.Invoke();
		}
	}
}
