using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCircular : MonoBehaviour
{
    public ItemMenuCirc[] objetos;
    public float radio;
    float angulo;
	public int actual;
	public AnimationCurve curvaAnimacion;
	float t;
	float rotAnterior;

	private void Start()
	{
		rotAnterior = 270;
	}

	[ContextMenu("Siguiente")]
	public void Siguiente()
	{
		actual = (actual + 1) % objetos.Length;
		IniciarGraficos();
	}

	[ContextMenu("Anterior")]
	public void Anterior()
	{
		actual = (actual + objetos.Length - 1) % objetos.Length;
		IniciarGraficos();
	}

	[ContextMenu("Iniciar")]
	public void IniciarGraficos()
	{
		t = 0;
		StartCoroutine(ActualizarGraficos());
	}
	public void AsignarAngulo(int cual)
	{
		actual = cual;
		IniciarGraficos();
	}

	IEnumerator ActualizarGraficos()
    {
		float rotSiguiente = 270 + (360f / (float)objetos.Length) * actual;
		while (t<1)
		{
			t += Time.deltaTime;
			transform.localEulerAngles = Vector3.up * (Mathf.LerpUnclamped(rotAnterior, rotSiguiente, curvaAnimacion.Evaluate(t)));
			yield return new WaitForEndOfFrame();
		}
		rotAnterior = rotSiguiente;
    }

	private void OnDrawGizmosSelected()
	{
		if (objetos.Length > 0)
		{
            angulo = 2 * Mathf.PI / (float)objetos.Length;
			for (int i = 0; i < objetos.Length; i++)
			{
				objetos[i].transform.localPosition = new Vector3(Mathf.Cos(i * angulo) * radio, 0, Mathf.Sin(i *  angulo) * radio);
				objetos[i].transform.forward = (objetos[i].transform.position-transform.position).normalized;
			}
		}
		objetos = gameObject.GetComponentsInChildren<ItemMenuCirc>();

	}


}
