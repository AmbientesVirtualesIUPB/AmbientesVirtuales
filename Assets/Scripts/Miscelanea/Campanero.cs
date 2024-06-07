using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campanero : MonoBehaviour
{
    public static Campanero singleton;

    public Transform cabezaVR;
    public Transform manoIzVR;
    public Transform manoDeVR;

    public ManoAnimaciones animDerecha;
    public ManoAnimaciones animIzquierda;

    void Awake()
    {
        singleton = this;
    }

}
