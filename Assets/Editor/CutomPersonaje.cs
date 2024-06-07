using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(EControlPersonaje))]
public class CutomPersonaje : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		EControlPersonaje objetivo = (EControlPersonaje)target;
		if(objetivo.tieneAnimator)
		{
			if (objetivo.animatorPersonaje == null)
			{
				EditorGUILayout.HelpBox("Falta agregar el Animator del personaje", MessageType.Error);
			}
			else
			{
				EditorGUILayout.HelpBox("Recuerda que debe tener por lo menos 3 variables, una tipo float para la velocidad, una tipo bool para saber si está en el piso y una tipo trigger para saber si está atacando", MessageType.Info);
			}
			if (objetivo.variableEstaEnPiso == "")
			{
				EditorGUILayout.HelpBox("Debes poner un nombre para saber si está en piso", MessageType.Error);
			}
			if (objetivo.variableVelocidad == "")
			{
				EditorGUILayout.HelpBox("Debes poner un nombre para saber si está caminando", MessageType.Error);
			}
		}
	}
}
