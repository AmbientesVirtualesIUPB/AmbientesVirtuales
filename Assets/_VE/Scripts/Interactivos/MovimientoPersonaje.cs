using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public MORIdentificador morIdentificador;
	public float velocidad;
    void Update()
    {
		if (morIdentificador != null)
		{
			if (morIdentificador.isOwner)
			{
				if (Inputstor.Velocidad().sqrMagnitude>0.1f)
				{
					transform.forward = Inputstor.Velocidad();
					transform.Translate(velocidad * Time.deltaTime * Inputstor.Magnitud()*Vector3.forward);
				}
			}
		}
    }
}
