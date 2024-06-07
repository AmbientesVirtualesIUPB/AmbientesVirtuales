using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Personajes/E Controlador")]
[RequireComponent(typeof(CharacterController))]
public class EControlPersonaje : MonoBehaviour
{
	CharacterController characterController;
	public MetodosMovimientoPersonaje metodo;
	public float velocidad = 6.0f;
	public float fuerzaDeSalto = 8.0f;
	public float gravedad = 20.0f;
	public float velocidadRotacion = 100;
	[Header("Animaciones")]
	public bool tieneAnimator;
	[ConditionalHide("tieneAnimator",true)]
	public Animator animatorPersonaje;
	[ConditionalHide("tieneAnimator", true)]
	public string variableVelocidad = "velocidad";
	[ConditionalHide("tieneAnimator", true)]
	public string variableEstaEnPiso = "enPiso";

	private Vector3 moveDirection = Vector3.zero;






	void Start()
	{
		characterController = GetComponent<CharacterController>();
	}

	private void Update()
	{
		switch (metodo)
		{
			case MetodosMovimientoPersonaje.Metodo1:
				Metodo1();
				break;
			case MetodosMovimientoPersonaje.Metodo2:
				Metodo2();
				break;
			default:
				break;
		}
	}

	void Metodo1()
	{
		if (characterController.isGrounded)
		{
			// Estamos en el piso
			// mover hacia la dirección que pidan

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection *= velocidad;
			if(moveDirection!=Vector3.zero) transform.forward = moveDirection;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = fuerzaDeSalto;
			}
		}

		// Aplicar gravedad
		moveDirection.y -= gravedad * Time.deltaTime;

		// Mover el personaje
		characterController.Move(moveDirection * Time.deltaTime);
		//Animar
		if (tieneAnimator && animatorPersonaje != null)
		{
			Vector3 nv = moveDirection;
			nv.y = 0;
			animatorPersonaje.SetFloat(variableVelocidad, nv.magnitude);
			animatorPersonaje.SetBool(variableEstaEnPiso, characterController.isGrounded);
		}
	}

	void Metodo2()
	{
		if (characterController.isGrounded)
		{

			transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime);
			moveDirection = transform.forward * Input.GetAxis("Vertical");
			moveDirection *= velocidad;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = fuerzaDeSalto;
			}
		}
		moveDirection.y -= gravedad * Time.deltaTime;
		
		characterController.Move(moveDirection * Time.deltaTime);
		//Animar
		if (tieneAnimator && animatorPersonaje != null)
		{
			Vector3 nv = moveDirection;
			nv.y = 0;
			animatorPersonaje.SetFloat(variableVelocidad, nv.magnitude);
			animatorPersonaje.SetBool(variableEstaEnPiso, characterController.isGrounded);
		}
	}

	public void CambiarVelocidad(float nv)
	{
		velocidad = nv;
	}
	public void SumarVelocidad(float nv)
	{
		velocidad += nv;
	}
	public void RestarVelocidad(float nv)
	{
		velocidad -= nv;
	}
}

public enum MetodosMovimientoPersonaje
{
	Metodo1,
	Metodo2
}