using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPaletas : MonoBehaviour
{
    public Personalizacion personalizacion;
    public GameObject prBoton;
    public Transform panelPiel;
    public Transform panelOjos;
    public Transform panelCabello;
    public Transform panelPrimario;
    public Transform panelSecundario;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < personalizacion.paletaPiel.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelPiel);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.piel;
        }

        for (int i = 0; i < personalizacion.paletaOjos.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelOjos);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.ojos;
        }

        for (int i = 0; i < personalizacion.paletaCabello.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelCabello);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.cabello;
        }

        for (int i = 0; i < personalizacion.paletaRopa.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelPrimario);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.ropa;
            btn.esPrincipal = true;
        }

        for (int i = 0; i < personalizacion.paletaRopa.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelSecundario);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.ropa;
            btn.esPrincipal = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
