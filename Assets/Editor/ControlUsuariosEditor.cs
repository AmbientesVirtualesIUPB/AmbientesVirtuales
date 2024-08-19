using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ControlUsuario))]
public class ControlUsuariosEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if (GUILayout.Button("Crear Jugador"))
		{
			ControlUsuario s = (ControlUsuario)target;
			s.CrearJugador();
		}
	}
}
