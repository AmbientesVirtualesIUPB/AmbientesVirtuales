using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Varios/E Creador")]
public class EInstanciador : MonoBehaviour
{
	public bool lista;
	[ConditionalHide("noLista", true)]
	public GameObject objeto;
	[ConditionalHide("lista", true)]
	public OrdenLista ordenInstancias;
	[ConditionalHide("lista", true)]
	public GameObject[] objetos;
	private int iObjetos = -1;

	[Header("Posiciones")]
	public OrdenLista ordenPosiciones;
	public Transform[] posiciones;
	private int iPosiciones = -1;

	[HideInInspector]
	public bool noLista;

    public void Instanciar()
    {
		if (posiciones.Length == 0 || (lista && objetos.Length == 0) || (!lista && objeto == null))
		{
			print("No está bien configurado para instanciar");
			return;
		}
		if (lista)
		{
			objeto = objetos[Random.Range(0, objetos.Length)];
		}
		if(ordenInstancias == OrdenLista.aleatorio)
		{
			iObjetos = Random.Range(0, objetos.Length);
		}
		else
		{
			iObjetos = (iObjetos + 1) % objetos.Length;
		}

		if (ordenPosiciones == OrdenLista.aleatorio)
		{
			iPosiciones = Random.Range(0, posiciones.Length);
		}
		else
		{
			iPosiciones = (iPosiciones + 1) % posiciones.Length;
		}
		GameObject gn = Instantiate(objeto, posiciones[iPosiciones].position, posiciones[iPosiciones].rotation) as GameObject;
		gn.SetActive(true);
	}

	private void OnDrawGizmosSelected()
	{
		noLista = !lista;
	}
}

public enum OrdenLista
{
	aleatorio,
	secuencial
}