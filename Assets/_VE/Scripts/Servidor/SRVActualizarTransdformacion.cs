using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRVActualizarTransdformacion : MonoBehaviour
{
    public float toleranciaPosicion;

    public float periodoEsperas = 0.5f;

    private float _toleranciaPosicion;
    public string id_conn;
    private Vector3 posAnterior;
    private Vector3 rotAnterior;

    public Vector3 posicionObjetivo;
    public Vector3 rotacionObjetivo;
    public bool isOwner;

    void Start()
    {
        posAnterior = transform.position;
        rotAnterior = transform.eulerAngles;
        _toleranciaPosicion = toleranciaPosicion * toleranciaPosicion;
        StartCoroutine(UpdateLento());
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
