using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EfectoBoton))]
public class BotonEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EfectoBoton boton = (EfectoBoton)target;
		if (GUILayout.Button("Activar")) 
		{
			boton.Activar();
		}
	}
}
