using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearPaletas : MonoBehaviour
{
<<<<<<< HEAD
    public Personalizacion  personalizacion;
    public GameObject       prBoton;
    public Transform        panelOjos;
    public Transform        panelCabello;
    public Transform        panelPrimario;
    public Transform        panelSecundario;
    public Transform        panelPiel;
=======
    public Personalizacion personalizacion;
    public GameObject prBoton;
    public Transform panelMaleta;
    public Transform panelOjos;
    public Transform panelCabello;
    public Transform panelPrimario;
    public Transform panelSecundario;
    public Transform panelPiel;

    [Header("Botones Zoom")]
    public Transform panelMaletaZ;
    public Transform panelOjosZ;
    public Transform panelCabelloZ;
    public Transform panelPrimarioZ;
    public Transform panelSecundarioZ;
    public Transform panelPielZ;



>>>>>>> origin/FIresnowwUi
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < personalizacion.paletaOjos.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelOjos);
            GameObject goz = Instantiate(prBoton, panelOjosZ);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            BtnColorPersonalizar btnz = goz.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.ojos;
            btnz.personalizacion = personalizacion;
            btnz.indice = i;
            btnz.tipo = TipoElemento.ojos;
        }

        for (int i = 0; i < personalizacion.paletaCabello.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelCabello);
            GameObject goz = Instantiate(prBoton, panelCabelloZ);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            BtnColorPersonalizar btnz = goz.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.cabello;
            btnz.personalizacion = personalizacion;
            btnz.indice = i;
            btnz.tipo = TipoElemento.cabello;
        }

        for (int i = 0; i < personalizacion.paletaRopa.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelPrimario);
            GameObject goz = Instantiate(prBoton, panelPrimarioZ);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            BtnColorPersonalizar btnz = goz.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.ropa;
            btn.esPrincipal = true;
            btnz.personalizacion = personalizacion;
            btnz.indice = i;
            btnz.tipo = TipoElemento.ropa;
            btnz.esPrincipal = true;
        }

        for (int i = 0; i < personalizacion.paletaRopa.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelSecundario);
            GameObject goz = Instantiate(prBoton, panelSecundarioZ);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            BtnColorPersonalizar btnz = goz.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.ropa;
            btn.esPrincipal = false;
            btnz.personalizacion = personalizacion;
            btnz.indice = i;
            btnz.tipo = TipoElemento.ropa;
            btnz.esPrincipal = false;
        }

        for (int i = 0; i < personalizacion.paletaPiel.Length; i++)
        {
            GameObject go = Instantiate(prBoton, panelPiel);
            GameObject goz = Instantiate(prBoton, panelPielZ);
            BtnColorPersonalizar btn = go.GetComponent<BtnColorPersonalizar>();
            BtnColorPersonalizar btnz = goz.GetComponent<BtnColorPersonalizar>();
            btn.personalizacion = personalizacion;
            btn.indice = i;
            btn.tipo = TipoElemento.piel;
            btn.esPrincipal = false;
            btnz.personalizacion = personalizacion;
            btnz.indice = i;
            btnz.tipo = TipoElemento.piel;
            btnz.esPrincipal = false;
        }
    }
}
