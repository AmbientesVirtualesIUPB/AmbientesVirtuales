using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teclado : MonoBehaviour
{
    public string[] tags;
    string letra;

    Vector3 tamañoBase;
    Vector3 tamañoMax = new Vector3(120f,120f,120f);

    float detener = 120f;
    bool Crece;

    public EstadoTeclado estadoT;

    string[] nums = { "0","1","2","3","4","5","6","7","8","9"};

    AudioSource audioScource;
    void Start()
    {
        letra = gameObject.name;
        audioScource = GetComponent<AudioSource>();
        tamañoBase = gameObject.GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Crece)
        {
            transform.localScale += (new Vector3(5f, 5f, 5f) * Time.deltaTime);
            if (detener >= tamañoMax.y)
            {
                transform.localScale = tamañoMax;
            }
        }
        if (!Crece)
        {
              transform.localScale = tamañoBase;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tags[0]) || other.CompareTag(tags[1]))
        {
            Crece = true;
            if (audioScource!=null)
            {
                audioScource.Play();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tags[0]) || other.CompareTag(tags[1]))
        {
            Crece = false;
            switch (letra)
            {
                default:
                    if (estadoT.estado == 0)
                    {
                        estadoT.textInNom.text += letra;
                        estadoT.BorrarTex();
                        estadoT.CambiarEstado();
                    }
                    else if (estadoT.estado == 1)
                    {
                        for (int i = 0; i < nums.Length; i++)
                        {
                            if (letra == nums[i])
                            {
                                estadoT.textInCC.text += letra;
                                break;
                            }
                        }    
                    }            
                    break;
                case "Enter":
                    if (estadoT.estado == 0)
                    {
                        estadoT.SumarEstado();
                        estadoT.CambiarEstado();
                    }
                    else if (estadoT.estado == 1)
                    {
                        estadoT.SumarEstado();
                        estadoT.CambiarEstado();
                    }
                    else if (estadoT.estado == 2)
                    {
                        estadoT.SumarEstado();
                        estadoT.CambiarEstado();
                    } 
                    break;
                case "Borrar":
                    if (estadoT.estado == 0)
                    {
                        estadoT.textInNom.text = estadoT.textInNom.text.Substring(0, estadoT.textInNom.text.Length - 1);
                    }
                    else if (estadoT.estado == 1)
                    {
                        estadoT.textInCC.text = estadoT.textInCC.text.Substring(0, estadoT.textInCC.text.Length - 1);                 
                    }    
                    break;
                case "Space":
                    if (estadoT.estado == 0)
                    {
                        estadoT.textInNom.text += " ";
                    }              
                    break;              
            }          
        }
    }

  
  
}
