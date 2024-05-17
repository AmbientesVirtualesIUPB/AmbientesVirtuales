using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Servidor))]
public class ServidorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Conectar"))
		{
			Servidor s = (Servidor)target;
			s.Conectar();
		}
	}
}
