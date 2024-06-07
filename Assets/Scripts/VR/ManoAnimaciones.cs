using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class ManoAnimaciones : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;

    public float tv;
    public float gv;

    public Animator animaciones;
    void Start()
    {
        if(animaciones == null) animaciones = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tv = pinchAnimationAction.action.ReadValue<float>();
        animaciones.SetFloat("Trigger", tv);
        gv = gripAnimationAction.action.ReadValue<float>();
        animaciones.SetFloat("Grip", gv);
    }
}
