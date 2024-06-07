using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escenas : MonoBehaviour
{
    public bool autocargar;
    [ConditionalHide("autocargar", true)]
    public float cuantoTiempo = 3;
    [ConditionalHide("autocargar", true)]
    public string nombreEscena = "Menu";

    /// <summary>
    /// Se ejecuta al iniciar el programa.
    /// </summary>
    void Start()
    {
        StartCoroutine(Autocargar());
    }
    /// <summary>
    /// Método implementado para cargar las escenas automáticamente después de que
    /// pase el tiempo previsto en la configuración
    /// </summary>
    public IEnumerator Autocargar()
    {
        yield return new WaitForSeconds(cuantoTiempo);
        if(autocargar) CargarEscena(nombreEscena);
    }
    /// <summary>
    /// Carga una escena nueva basado en el nombre de la misma
    /// </summary>
    /// <param name="nombre"></param>
    public void CargarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    /// <summary>
    /// Cierra la aplicación
    /// </summary>
    public void Salir()
    {
        Application.Quit();
    }
}
