using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;


public class PreguntasFrecuentes : MonoBehaviour
{
    public float pos;
    public RectTransform contenedor;

    public GameObject[] Instancias;
    public GameObject cargando;

    public GameObject[] menu;
    public GameObject[] Entreda1;
    public GameObject[] subMenu1_1;
    public GameObject[] subMenu1_2;
    public GameObject[] Entreda2;
    public GameObject[] Entreda3;
    public GameObject[] subMenu3_1;
    public GameObject[] Entreda4;
    public GameObject[] Entreda5;


    public int orden;
    public bool entraText;

    public float tiempoAparicion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Descender() 
    {
        
        contenedor.anchoredPosition += new Vector2(0, pos);
        float proces = pos * 0.05f;
        pos += proces;

    }
    public void Menu1() 
    {
        orden = 0;
        StartCoroutine(carga(orden));

    } 
    public void Menu2()
    {
        orden = 1;
        StartCoroutine(carga(orden));
    }
    public void Menu3()
    {
        orden = 2;
        StartCoroutine(carga(orden));
    }
    public void Menu4()
    {
        orden = 3;
        StartCoroutine(carga(orden));
    }
    public void Menu5()
    {
        orden = 4;
        StartCoroutine(carga(orden));
    }

    IEnumerator carga(int i)
    {

        cargando.transform.SetAsLastSibling();
        Descender();
        cargando.SetActive(true);
        yield return new WaitForSeconds(tiempoAparicion);
        cargando.SetActive(false);
        Instantiate(Instancias[i], contenedor);
        Descender();

    }
}
