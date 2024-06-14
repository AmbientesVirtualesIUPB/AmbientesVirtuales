using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MORIdentificador))]
public class SRVPersonaje : MonoBehaviour
{
	[HideInInspector]
    public MORIdentificador identificador;
    public string id_uss;
	public bool conectado = false;
	public Color[] colores;
	public Plataforma plataforma;

	private void Awake()
	{
		if(identificador == null) 
			identificador = GetComponent<MORIdentificador>();
	}
	public void Inicializar(string _id_con, string _id_uss, bool _isOwner)
	{
		print("---> Inicializar SRVPersonaje");
		if (identificador == null) 
			identificador = GetComponent<MORIdentificador>();
		id_uss = _id_uss;
		identificador.Inicializar(_isOwner, _id_con);
	}

	public void Inicializar(string _id_con, string _id_uss, bool _isOwner, Plataforma _plataforma)
	{
		plataforma = _plataforma;
		Inicializar(_id_con, _id_uss, _isOwner);
	}
	void Start()
    {
		if (identificador.isOwner)
		{
            Servidor.singleton.EventoConectado += OnConnectedToServer;
		}
		else
		{
			int k = int.Parse(id_uss.Substring(0, 1));
			//GetComponent<MeshRenderer>().material.SetColor("_BaseColor", colores[k]);
		}
    }

	public void OnConnectedToServer()
	{
		conectado = true;
		//id_con = ControlUsuario.singleton.id_con;
		//id_uss = ControlUsuario.singleton.id_uss;
		int k = int.Parse(id_uss.Substring(0, 1));
		//GetComponent<MeshRenderer>().material.SetColor("_BaseColor", colores[k]);
	}

	private void OnDestroy()
	{
		if (identificador.isOwner)
		{
			Servidor.singleton.EventoConectado -= OnConnectedToServer;
		}
	}
}
