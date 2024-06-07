using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[AddComponentMenu("Exploración/Condicionales/E Condicion Palabras")]
public class ECondicionPalabras : MonoBehaviour
{
	public EVariables variable1;
	[Header("Tipo de comparación")]
	public TipoComparacionPalabra tipoDeComparacion;
	public ConQueComparar compararCon;
	[ConditionalHide("estaEnVariable", true)]
	public EVariables variable2;
	[ConditionalHide("estaEnValor", true)]
	public string valor;
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

	[HideInInspector]
	public bool estaEnVariable = true;
	[HideInInspector]
	public bool estaEnValor = false;
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
		string f1 = variable1.variablePalabra;
		string f2 = valor;
		if (compararCon == ConQueComparar.variable)
		{
			f2 = variable2.variablePalabra;
		}
		bool siCumplio = false;
		switch (tipoDeComparacion)
		{
			case TipoComparacionPalabra.igual:
				siCumplio = f1 == f2;
				break;
			case TipoComparacionPalabra.diferente:
				siCumplio = f1 != f2;
				break;
			case TipoComparacionPalabra.contieneA:
				siCumplio = f1.Contains(f2);
				break;
			default:
				break;
		}
		if (siCumplio)
		{
			siSeCumple.Invoke();
		}
		else
		{
			noSeCumple.Invoke();
		}
	}

	private void OnDrawGizmosSelected()
	{
		estaEnValor = (compararCon == ConQueComparar.valor);
		estaEnVariable = !estaEnValor;
	}
}

public enum TipoComparacionPalabra
{
	igual,
	diferente,
	contieneA
}

