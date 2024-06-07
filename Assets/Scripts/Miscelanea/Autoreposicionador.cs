using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoreposicionador : MonoBehaviour
{
    public Transform referencia;
    
    public Vector3 offset;
    public float velocidad;
    Vector3 rotacion;

    private void Start()
    {
        rotacion = transform.localEulerAngles;
    }
    [ContextMenu("Calcular offset")]
    public void CalcularOffset()
    {
        offset = referencia.position - transform.position;    
    }

    void Update()
    {
        transform.position = referencia.position - offset;
        rotacion.y = Mathf.Lerp(rotacion.y, referencia.localEulerAngles.y, velocidad * Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(rotacion), velocidad * Time.deltaTime);
    }
}
