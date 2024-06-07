using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EstadoTeclado : MonoBehaviour
{
    public int estado;


    public InputField textInNom;
    public Text Nombre;


    public InputField textInCC;
    public Text Cc;

    Color colorbaseN;
    Color colorbaseC;
    // Start is called before the first frame update
    void Start()
    {
        estado = 0;
        Nombre.text = string.Empty;
        Cc.text = string.Empty;
        colorbaseN = textInNom.image.color;
        colorbaseC = textInCC.image.color;
    }

  public void SumarEstado()
    {      
        estado++;
        if (estado == 2)
        {
            ActulizarText();
            estado = 0;
        } 
    }
    public void ActulizarText()
    {

        Nombre.text = textInNom.text;
        Cc.text = textInCC.text;

        textInNom.text = string.Empty;
        textInCC.text = string.Empty;

    }
    public void BorrarTex()
    {
        Nombre.text = string.Empty;
        Cc.text = string.Empty;
    }
    public void CambiarEstado() 
    {
        if (estado == 0 )
        {
            textInNom.image.color = new Color(66f, 169f, 245f);
            textInCC.image.color = colorbaseC;
        }
        if (estado == 1)
        {
            textInNom.image.color = colorbaseN;
            textInCC.image.color = new Color(66f, 169f, 245f);
        }
        if (estado == 2)
        {
            textInNom.image.color = colorbaseN;
            textInCC.image.color = colorbaseC;
        }
    }
}
