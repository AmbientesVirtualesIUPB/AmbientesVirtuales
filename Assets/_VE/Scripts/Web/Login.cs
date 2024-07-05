using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    //Referencia al servidor para conexion
    public Servidor         servidor;
    public TMP_InputField   InputUsuario;
    public TMP_InputField   InputPass;
    public GameObject       imloading;
    public DBusuario        usuario;


    public void IniciarSesion()
    {
        StartCoroutine(Iniciar());
    }


    IEnumerator Iniciar()
    {
        imloading.SetActive(true);
        string[] datos = new string[2];
        datos[0] = InputUsuario.text;
        datos[1] = InputPass.text;

        StartCoroutine(servidor.ConsumirServicio("login", datos, PosCarga));

        yield return new WaitForSeconds(0.5f);

        //Esperar hasta que se desactiva el ocupado
        yield return new WaitUntil(() => !servidor.ocupado);
        imloading.SetActive(false);
    }


    void PosCarga()
    {

        switch (servidor.respuesta.codigo)
        {

            case 204: //Usuario o password son incorrectos
                print(servidor.respuesta.mensaje);
                break;

            case 205: //Inicio de sesion correcto
                SceneManager.LoadScene("Scena2");
                //Mostrar los datos del usuario
                //usuario = JsonUtility.FromJson<DBusuario>(servidor.respuesta.respuesta);
                break;

            case 402: //Faltan datos para ejecutar la consulta
                print(servidor.respuesta.mensaje);
                break;

            case 404: //Error en la ejecucion
                print("No hay conexion con el servidor");
                break;

            default:
                break;
        }
    }
}
