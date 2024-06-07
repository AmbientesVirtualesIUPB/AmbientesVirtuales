using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Exploración/Fisicas/E Colisionador")]

public class EColisionador : MonoBehaviour
{
	public string tag;
	public bool compararTag;

	[Header("Triggers")]
	public UnityEvent iniciaTrigger;
	public UnityEvent estaEnTrigger;
	public UnityEvent terminaTrigger;

	[Header("Collisions")]
	public UnityEvent iniciaCollision;
	public UnityEvent estaEnCollision;
	public UnityEvent terminaCollision;

	private void OnTriggerEnter(Collider other)
	{
		if (compararTag && !other.CompareTag(tag)) return;
		iniciaTrigger.Invoke();
	}
	private void OnTriggerStay(Collider other)
	{
		if (compararTag && !other.CompareTag(tag)) return;
		estaEnTrigger.Invoke();
	}
	private void OnTriggerExit(Collider other)
	{
		if (compararTag && !other.CompareTag(tag)) return;
		terminaTrigger.Invoke();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (compararTag && !collision.gameObject.CompareTag(tag)) return;
		iniciaCollision.Invoke();
	}
	private void OnCollisionStay(Collision collision)
	{
		if (compararTag && !collision.gameObject.CompareTag(tag)) return;
		estaEnCollision.Invoke();
	}
	private void OnCollisionExit(Collision collision)
	{
		if (compararTag && !collision.gameObject.CompareTag(tag)) return;
		terminaCollision.Invoke();
	}
}
