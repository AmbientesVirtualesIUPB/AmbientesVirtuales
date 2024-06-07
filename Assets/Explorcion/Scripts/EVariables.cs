using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Variables/E Variables")]
public class EVariables : MonoBehaviour
{
	[Header("Numérica")]
	public float variableNumerica;
	public bool restringirValor;
	[ConditionalHide("restringirValor", true)]
	public Vector2 minimoMaximo;
	[Header("Palabra")]
	public string variablePalabra;
	[Header("Vector")]
	public Vector3 variableVectorial;

	public void CambiarNumero(float nuevoValor)
	{
		variableNumerica = nuevoValor;
		if (restringirValor)
		{
			variableNumerica = Mathf.Clamp(variableNumerica, minimoMaximo.x, minimoMaximo.y);
		}
	}

	public void SumarAlNumero(float nuevoValor)
	{
		variableNumerica += nuevoValor;
		if (restringirValor)
		{
			variableNumerica = Mathf.Clamp(variableNumerica, minimoMaximo.x, minimoMaximo.y);
		}
	}

	public void RestarAlNumero(float nuevoValor)
	{
		variableNumerica -= nuevoValor;
		if (restringirValor)
		{
			variableNumerica = Mathf.Clamp(variableNumerica, minimoMaximo.x, minimoMaximo.y);
		}
	}

	public void MultiplicarAlNumero(float nuevoValor)
	{
		variableNumerica *= nuevoValor;
		if (restringirValor)
		{
			variableNumerica = Mathf.Clamp(variableNumerica, minimoMaximo.x, minimoMaximo.y);
		}
	}

	public void DividirAlNumero(float nuevoValor)
	{
		if (nuevoValor == 0)
			return;
		variableNumerica /= nuevoValor;
		if (restringirValor)
		{
			variableNumerica = Mathf.Clamp(variableNumerica, minimoMaximo.x, minimoMaximo.y);
		}
	}

	public void CambiarPalabra(string nuevoValor)
	{
		variablePalabra = nuevoValor;
	}

	public void AgregarALaPalabra(string nuevoValor)
	{
		variablePalabra += nuevoValor;
	}

	public void CambiarVector(Vector3 nv)
	{
		variableVectorial = nv;
	}

	public void CambiarVectorPorPosicion(Transform nv)
	{
		variableVectorial = nv.position;
	}

	public void CambiarVectorPorRotacion(Transform nv)
	{
		variableVectorial = nv.localEulerAngles;
	}

	public void CambiarVectorPorEscala(Transform nv)
	{
		variableVectorial = nv.localScale;
	}
}
