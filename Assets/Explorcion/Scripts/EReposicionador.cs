using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Varios/E Reposicionador")]
public class EReposicionador : MonoBehaviour
{
	public Transform[] posiciones;
	int indice;
	bool reposicionando;
	public float velocidad;
	public float velRotacion;

	bool reposicionandoVector= false;
	Vector3 nPosicionVectorial;

	public void Reposicionar(int i)
	{
		if (i < 0 || i >= posiciones.Length)
			return;
		indice = i;
		reposicionando = true;
	}

	public void Reposicionar(EVariables i)
	{
		Reposicionar(Mathf.FloorToInt(i.variableNumerica));
	}

	public void ReposicionarAVector(EVariables i)
	{
		if (i == null)
			return;
		nPosicionVectorial = i.variableVectorial;
		reposicionandoVector = true;
	}
	void Update()
	{
		if (reposicionando)
		{
			if ((transform.position - posiciones[indice].position).sqrMagnitude > 0.05f || (transform.localEulerAngles - posiciones[indice].localEulerAngles).sqrMagnitude > 0.05f)
			{
				transform.position = Vector3.Lerp(transform.position, posiciones[indice].position, velocidad * Time.deltaTime);
				transform.localEulerAngles = Vector3.Lerp(transform.localEulerAngles, posiciones[indice].localEulerAngles, velRotacion * Time.deltaTime);
			}
			else
			{
				reposicionando = false;
			}
		}
		if (reposicionandoVector)
		{
			if ((transform.position - nPosicionVectorial).sqrMagnitude > 0.05f)
			{
				transform.position = Vector3.Lerp(transform.position, nPosicionVectorial, velocidad * Time.deltaTime);
			}
			else
			{
				reposicionandoVector = false;
			}
		}
	}

}
