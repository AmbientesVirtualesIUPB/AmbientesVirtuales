using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Varios/E Transformador")]
public class ETransformador : MonoBehaviour
{
	public bool rotar;
	[ConditionalHide("rotar",true)]
	public Vector3 velRotacion;
	public bool mover;
	[ConditionalHide("mover",true)]
	public Vector3 velocidad;
	public bool escalar;
	[ConditionalHide("escalar",true)]
	public Vector3 escala;

    void Start()
    {
        
    }
	
    void Update()
    {
		if (rotar)
		{
			transform.Rotate(velRotacion * Time.deltaTime);
		}
		if (mover)
		{
			transform.Translate(velocidad * Time.deltaTime);
		}
		if (escalar)
		{
			transform.localScale = transform.localScale + escala*Time.deltaTime;
		}
    }

	public void CambioEstadoRotar(bool nuevoEstado)
	{
		rotar = nuevoEstado;
	}
	public void CambioEstadoMover(bool nuevoEstado)
	{
		mover = nuevoEstado;
	}
	public void CambioEstadoEscalar(bool nuevoEstado)
	{
		escalar = nuevoEstado;
	}
}
