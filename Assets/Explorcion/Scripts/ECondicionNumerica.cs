using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[AddComponentMenu("Exploración/Condicionales/E Condicion Numérica")]
public class ECondicionNumerica : MonoBehaviour
{
	public EVariables variable1;
	[Header("Tipo de comparación")]
	public TipoComparacionNumerica tipoDeComparacion;
	public ConQueComparar compararCon;
	[ConditionalHide("estaEnVariable", true)]
	public EVariables variable2;
	[ConditionalHide("estaEnValor", true)]
	public float valor;
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
		float f1 = variable1.variableNumerica;
		float f2 = valor;
		if (compararCon == ConQueComparar.variable)
		{
			f2 = variable2.variableNumerica;
		}
		bool siCumplio = false;
		switch (tipoDeComparacion)
		{
			case TipoComparacionNumerica.menor:
				siCumplio = (f1 < f2);
				break;
			case TipoComparacionNumerica.menorOIgual:
				siCumplio = (f1 <= f2);
				break;
			case TipoComparacionNumerica.igual:
				siCumplio = (f1 == f2);
				break;
			case TipoComparacionNumerica.mayorOIgual:
				siCumplio = (f1 >= f2);
				break;
			case TipoComparacionNumerica.mayor:
				siCumplio = (f1 > f2);
				break;
			case TipoComparacionNumerica.diferente:
				siCumplio = (f1 != f2);
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

public enum ConQueComparar
{
	variable,
	valor
}

public enum TipoComparacionNumerica
{
	menor,
	menorOIgual,
	igual,
	mayorOIgual,
	mayor,
	diferente
}

