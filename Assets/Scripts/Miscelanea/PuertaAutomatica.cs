using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaAutomatica : MonoBehaviour
{
    public float        rango = 2;
    public Animator     animaciones;
    public Transform    objetivo;
    public AudioSource  audioPuerta;

    IEnumerator Start()
    {
        float r2 = rango * rango;
        if (animaciones != null && objetivo != null)
        {
            bool anterior = false;
            while (true)
            {
                yield return new WaitForSeconds(1);
                bool anterior2 = (transform.position - objetivo.position).sqrMagnitude < r2;
                animaciones.SetBool("cerca", anterior2);
                if (anterior != anterior2)
                {
                    audioPuerta.Play();
                }
                anterior = anterior2;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
