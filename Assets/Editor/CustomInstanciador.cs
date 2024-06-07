using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(EInstanciador))]
public class CustomInstanciador : Editor
{
	public override void OnInspectorGUI()
	{
		EInstanciador objeto = (EInstanciador)target;
		base.OnInspectorGUI();
		if (GUILayout.Button("Instanciar"))
		{
			objeto.Instanciar();
		}
	}
}
