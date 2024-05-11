using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlUsuario : MonoBehaviour
{
    public static ControlUsuario singleton;
	public string	id_con;
	public string	id_uss;
	public bool		fakeInicio = true;
	public GameObject gmJugador;

	public List<string> ids;
	public Dictionary<string, GameObject> usuarios;

	private void Awake()
	{
		if (singleton != null)
		{
			DestroyImmediate(gameObject);
			return;
		}
		else
		{
			singleton = this;
		}
	}

	private void Start()
	{
		usuarios = new Dictionary<string, GameObject>();
		if (fakeInicio)
		{
			id_con = "US" + Random.Range(1111, 9999).ToString();
			id_uss = Random.Range(1111, 9999).ToString();
		}
	}

	public void CrearJugador()
	{
		GameObject jugador = Instantiate(GestionMensajesServidor.singeton.prJugador);
		SRVPersonaje personaje = jugador.GetComponent<SRVPersonaje>();
		personaje.Inicializar(id_con, id_uss, true);
		gmJugador = jugador;
	}

	public Presentacion GetPresentacion()
	{
		Presentacion p = new Presentacion();
		p.id_con = id_con;
		p.id_uss = id_uss;
		p.plataforma = 0;   // Esto está pendiente de cambiar por la plataforma real
		p.posicion = gmJugador.transform.position;
		p.rotacion = gmJugador.transform.eulerAngles;
		return p;
	}

	public void AgregarUsuario(string _id_conn, GameObject _jugador)
	{
		usuarios.Add(_id_conn, _jugador);
		ids.Add(_id_conn);
	}
}
