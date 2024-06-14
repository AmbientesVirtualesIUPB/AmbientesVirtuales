using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Personalizacion))]

public class ElementoPersonalizableEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Siguiente Hombre"))
        {
            Personalizacion ep = (Personalizacion)target;
            ep.partesHombre[0].Siguiente();
        }
    }
}
