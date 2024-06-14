using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SRVPersonaje))]
public class SRVActualizarTransdformacion : MonoBehaviour
{
    public float toleranciaPosicion = 0.2f;

    public float periodoEsperas = 0.2f;

    private float _toleranciaPosicion;
    public string id_conn;
    private Vector3 posAnterior;
    private Vector3 rotAnterior;

    public Vector3 posicionObjetivo;
    public Vector3 rotacionObjetivo;
    public bool isOwner;
    public Plataforma plataforma;
    SRVPersonaje srvPersonaje;

    private void Awake()
    {
        srvPersonaje = GetComponent<SRVPersonaje>();
    }
    IEnumerator Start()
    {
        posAnterior = transform.position;
        rotAnterior = transform.eulerAngles;
        _toleranciaPosicion = toleranciaPosicion * toleranciaPosicion;
        StartCoroutine(UpdateLento());
        yield return new WaitUntil(() => srvPersonaje.conectado);
        yield return new WaitForSeconds(0.2f);
        id_conn = srvPersonaje.identificador.id_con;
        isOwner = srvPersonaje.identificador.isOwner;
    }

    public void Inicializar(Vector3 posicion, Vector3 rotacion)
    {
        transform.position = posicion;
        transform.eulerAngles = rotacion;
        posAnterior = transform.position;
        rotAnterior = transform.eulerAngles;
    }
    public void Inicializar(Vector3 _posicion, Vector3 _rotacion, Plataforma _plataforma)
    {
        Inicializar(_posicion, _rotacion);
        plataforma = _plataforma;
    }

    IEnumerator UpdateLento()
    {
		while (true)
		{
			if ((posAnterior - transform.position).sqrMagnitude > _toleranciaPosicion ||
                (rotAnterior - transform.eulerAngles).sqrMagnitude > _toleranciaPosicion*50)
			{
                // ********************************* OJO CON ESTE QUE SOLO MANDA MOVIL! ***********************
                GestionMensajesServidor.singeton.EnviarActualizacionTransform(id_conn, transform, Plataformas.Movil);
			}
            posAnterior = transform.position;
            rotAnterior = transform.eulerAngles;
            yield return new WaitForSeconds(periodoEsperas);
		}
    }

	private void Update()
	{
		if (!isOwner)
		{
            transform.position = Vector3.Lerp(transform.position, posicionObjetivo, Time.deltaTime * 5);
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.eulerAngles), Quaternion.Euler(rotacionObjetivo), Time.deltaTime * 5);
        }
	}


}
