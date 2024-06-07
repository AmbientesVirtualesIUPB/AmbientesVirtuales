using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animador : MonoBehaviour
{
    public float velocidad;
    public bool rotar;
    [ConditionalHide("rotar", true)]
    public Vector3 velRotacion;

    public bool escalar;
    [ConditionalHide("escalar", true)]
    public Vector3 escalaInicial = Vector3.one;
    [ConditionalHide("escalar", true)]
    public Vector3 escalaFinal = Vector3.one;
    [ConditionalHide("escalar", true)]
    public AnimationCurve curva;

    float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t>1)
        {
            t = 0;
        }
        if (rotar)
        {
            transform.Rotate(velRotacion * velocidad * Time.deltaTime);
        }
        if (escalar)
        {
            transform.localScale = Vector3.Lerp(escalaInicial, escalaFinal, curva.Evaluate(t));
        }
    }
}
