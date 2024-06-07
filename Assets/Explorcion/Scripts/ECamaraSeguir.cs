using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Personajes/E CamaraSeguir")]
public class ECamaraSeguir : MonoBehaviour
{
	public Transform	objetivo;
	public float		distancia = 5f;
	public float		altura = 2f;
	public bool			suavizarMovimiento = false;         
	public float		suavidadDeVelocidad = 5f;
	public bool			usarDireccionQuemada = false;      
	public Vector3		direccionQuemada = Vector3.one;

	
	void Update()
	{

		Vector3 lookToward = objetivo.position - transform.position;
		if (usarDireccionQuemada)
			lookToward = direccionQuemada;


		//make it stay a fixed distance behind ball
		Vector3 newPos;
		newPos = objetivo.position - lookToward.normalized * distancia;
		newPos.y = objetivo.position.y + altura;

		if (!suavizarMovimiento)
		{
			transform.position = newPos;    //move exactly to follow target
		}
		else   //  smoothed / soft follow
		{
			transform.position += (newPos - transform.position) * Time.deltaTime * suavidadDeVelocidad;
		}

		//re- calculate look direction (dont' do this line if you want to lag the look a little
		lookToward = objetivo.position - transform.position;

		//make this camera look at target
		transform.forward = lookToward.normalized;
	}
}
