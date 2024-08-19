using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputstor : MonoBehaviour
{
    public static float h1, h2, h3;
    public static float v1, v2, v3;

    public static float GetHorizontal()
    {
        return (h1 + h2 + h3);
    }
    public static float GetVertical()
    {
        return (v1 + v2 + v3);
    }

    public static Vector3 Velocidad()
	{
        return new Vector3(GetHorizontal(), 0, GetVertical());
	}

    public static float Magnitud()
	{
        return Mathf.Clamp((Mathf.Sign(GetHorizontal()) * GetHorizontal() + Mathf.Sign(GetVertical()) * GetVertical()), 0, 1);
	}
}
