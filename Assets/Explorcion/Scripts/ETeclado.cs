using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("Exploración/Varios/E Teclado")]
public class ETeclado : MonoBehaviour
{
	public ETecla[] pulsar;
	public ETecla[] pulsando;
	public ETecla[] despulsar;
	
    void Update()
    {
		foreach (ETecla eTecla in pulsar)
		{
			if (Input.GetKeyDown(eTecla.tecla))
			{
				eTecla.accion.Invoke();
			}
		}
		foreach (ETecla eTecla in pulsando)
		{
			if (Input.GetKey(eTecla.tecla))
			{
				eTecla.accion.Invoke();
			}
		}
		foreach (ETecla eTecla in despulsar)
		{
			if (Input.GetKeyUp(eTecla.tecla))
			{
				eTecla.accion.Invoke();
			}
		}
	}
}
[System.Serializable]
public class ETecla
{
	public KeyCode tecla;
	public UnityEvent accion;
}
