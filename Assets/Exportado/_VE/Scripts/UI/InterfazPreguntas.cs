    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;

public class InterfazPreguntas : MonoBehaviour
{
    public GameObject[] entrada;
    public GameObject[] Salida;
    //[SerializeField]
    //private Vector3[] PosInicial;
    Vector3 PosFinal;

    public bool este = false;


    void Start()
    {
       /* for (int i = 0; i < PosInicial.Length; i++)
        {
            PosInicial[i] = entrada[i].transform.localScale;
        }

        PosFinal = new Vector3(0, 0, 0);
       */
    }

    void Update()
    {
        if (este)
        {
            StartCoroutine("Acr");
            este = false;

        }
    }

    public void Entrar()
    {

        StartCoroutine("Acr");

    }

    /*        IEnumerator Acr()
            {
                // Desactivar objetos en Salida y escalar a 0
                for (int i = 0; i < Salida.Length; i++)
                {
                    yield return new WaitForSeconds(0.2f);
                    StartCoroutine(EscalarObjeto(Salida[i].transform, PosFinal));
                    Salida[i].gameObject.SetActive(false);
                }

                yield return new WaitForSeconds(0.5f);

                // Activar objetos en Entrada y escalar a su tama�o original
                for (int i = 0; i < entrada.Length; i++)
                {
                    yield return new WaitForSeconds(0.2f);
                    entrada[i].gameObject.SetActive(true);
                    yield return StartCoroutine(EscalarObjeto(entrada[i].transform, PosInicial[i]));

            }
        }

            IEnumerator EscalarObjeto(Transform objetoTransform, Vector3 escalaFinal)
            {
                float duracion = 0.2f; // Duraci�n de la transici�n

                Vector3 escalaInicial = objetoTransform.localScale;
                float tiempoPasado = 0f;

                while (tiempoPasado < duracion)
                {
                    objetoTransform.localScale = Vector3.Lerp(escalaInicial, new Vector3(escalaFinal.x, escalaFinal.y, escalaFinal.z), tiempoPasado / duracion);
                    tiempoPasado += Time.deltaTime;
                    yield return null;
                }

                objetoTransform.localScale = new Vector3(escalaFinal.x, escalaFinal.y, escalaFinal.z); 
            }
        }
    */
    public IEnumerator Acr()
    {

        for (int i = 0; i < entrada.Length; i++)
        {

           // yield return new WaitForSeconds(0.2f);
            entrada[i].gameObject.SetActive(true);
        }
        //yield return new WaitForSeconds(0.1f);

        for (int i = 0; i < Salida.Length; i++)
        {

            //yield return new WaitForSeconds(0.2f);
            Salida[i].gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
    }
}
