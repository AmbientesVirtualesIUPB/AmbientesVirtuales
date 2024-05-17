using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Este script se utiliza para dar a un objeto un ID dentro de la red, 
/// pero es un ID de conexión
/// </summary>
public class MORIdentificador : MonoBehaviour
{
    public string id_con;
    public bool isOwner;

    public string Inicializar(bool _isOwner,  string _id_con)
    {
        print("---> Inicializar MORIdentificador " + _isOwner + " - " + _id_con);
        isOwner = _isOwner;
		if (isOwner)
		{
            id_con = "M" + Random.Range(1000, 9999) + "O" + Random.Range(1000, 9999);
		}
		else
		{
            id_con = _id_con;
        }
        return id_con;
    }
    public string Inicializar(bool _isOwner)
    {
        return Inicializar(_isOwner, "");
    }
}
