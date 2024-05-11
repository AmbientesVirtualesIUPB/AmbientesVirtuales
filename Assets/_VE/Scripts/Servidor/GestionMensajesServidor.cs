using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMensajesServidor : MonoBehaviour
{
	public static GestionMensajesServidor singeton;

	public GameObject prJugador;
	public CambioTransform cambioTransform;

	public delegate void CambioTransform(string id_con, Vector3 pos, Vector3 rot);

	private void Awake()
	{
		singeton = this;
	}

	public void RecibirMensaje(string mensaje)
	{
		print("MENSAJE:" + mensaje);
		string codigo = mensaje.Substring(0, 4);
		string msj = mensaje.Substring(4);
		switch (codigo)
		{
			case "PR00":
				PR00(msj);
				break;
			case "AT00":
				AT00(msj);
				break;
			case "AC00":
				AC00(msj);
				break;
			default:
				break;
		}
	}

	public void EnviarMensaje(string msj)
	{
		Servidor.singleton.EnviarMensaje(msj);
	}

	public void PR00(string msj)
	{
		//print("-------->" + msj);
		Presentacion p = JsonUtility.FromJson<Presentacion>(msj);
		if (!ControlUsuario.singleton.ids.Contains(p.id_con))
		{
			GameObject go = Instantiate(prJugador, p.posicion, Quaternion.identity);
			ControlUsuario.singleton.AgregarUsuario(p.id_con, go);
			SRVPersonaje sp = go.GetComponent<SRVPersonaje>();
			SRVActualizarTransdformacion sATra = go.GetComponent<SRVActualizarTransdformacion>();
			sATra.posicionObjetivo = p.posicion;
			sATra.rotacionObjetivo = p.rotacion;
			sp.Inicializar(p.id_con, p.id_uss, false);
			go.name = p.id_uss;
			sp.conectado = true;
		}
	}

	public void AT00(string msj)
	{
		Posicion0 p = JsonUtility.FromJson<Posicion0>(msj);
		if (ControlUsuario.singleton.usuarios.ContainsKey(p.id_con))
		{
			Transform t = ControlUsuario.singleton.usuarios[p.id_con].transform;
			SRVActualizarTransdformacion a = t.GetComponent<SRVActualizarTransdformacion>();
			a.posicionObjetivo = p.posicion;
			a.rotacionObjetivo = p.rotacion;
		}
	}
	public void AC00(string msj)
	{
		Presentacion p = ControlUsuario.singleton.GetPresentacion();
		string pJson = JsonUtility.ToJson(p);
		EnviarMensaje("PR00" + pJson);
	}

	public void EnviarActualizacionTransform(string _id_conn, Transform tr, Plataformas pl)
	{
		string msj = "";
		Posicion0 p0 = new Posicion0();

		switch (pl)
		{
			case Plataformas.Movil:
				msj = "AT00";
				p0.id_con = _id_conn;
				p0.posicion = tr.position;
				p0.rotacion = tr.eulerAngles;
				msj += JsonUtility.ToJson(p0);
				break;
			case Plataformas.Windows:
				msj = "AT00";
				p0.id_con = _id_conn;
				p0.posicion = tr.position;
				p0.rotacion = tr.eulerAngles;
				msj += JsonUtility.ToJson(p0);
				break;
			case Plataformas.VR:
				break;
			default:
				break;
		}
		EnviarMensaje(msj);
	}
}
