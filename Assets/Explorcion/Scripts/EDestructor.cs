using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Exploración/Varios/E Destructor")]
public class EDestructor : MonoBehaviour
{
	public bool autodestruir;
	[ConditionalHide("autodestruir", true)]
	public float retardo;
	
    void Start()
    {
		if (autodestruir)
		{
			Destroy(gameObject, retardo);
		}
    }

    public void Destruir()
	{
		Destroy(gameObject);
	}

	public void DestruirConRetardoDe(float cuanto)
	{
		Destroy(gameObject, cuanto);
	}
	
}
