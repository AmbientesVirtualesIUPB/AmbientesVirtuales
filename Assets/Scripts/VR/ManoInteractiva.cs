using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ManoInteractiva : MonoBehaviour
{
    public InputActionProperty pinchControl;
    public GameObject rayo;
    public float valor;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valor = pinchControl.action.ReadValue<float>();
        bool activo = pinchControl.action.ReadValue<float>()>0.4f;
        rayo.SetActive(activo);

    }
}
