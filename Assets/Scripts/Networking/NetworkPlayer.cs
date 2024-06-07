using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviour
{
    public Transform cabeza;
    public Transform manoIzquierda;
    public Transform manoDerecha;
    public Animator animManoDerecha;
    public Animator animManoIzquierda;

    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            foreach (Renderer item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            MapearPosiciones();
            ActualizarAnimaciones(animManoDerecha, Campanero.singleton.animDerecha);
            ActualizarAnimaciones(animManoIzquierda, Campanero.singleton.animIzquierda);
        }
        
    }

    public void ActualizarAnimaciones(Animator animaciones, ManoAnimaciones manoAnimaciones)
    {
        animaciones.SetFloat("Trigger", manoAnimaciones.tv);
        animaciones.SetFloat("Grip", manoAnimaciones.gv);
    }

    public void MapearPosicion(Transform objetivo, XRNode nodo)
    {
        InputDevices.GetDeviceAtXRNode(nodo).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos);
        InputDevices.GetDeviceAtXRNode(nodo).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot);

        objetivo.position = pos;
        objetivo.rotation = rot;
    }
    public void MapearPosiciones()
    {
        manoDerecha.position = Campanero.singleton.manoDeVR.position;
        manoDerecha.rotation = Campanero.singleton.manoDeVR.rotation;
        manoIzquierda.position = Campanero.singleton.manoIzVR.position;
        manoIzquierda.rotation = Campanero.singleton.manoIzVR.rotation;
        cabeza.position = Campanero.singleton.cabezaVR.position;
        cabeza.rotation = Campanero.singleton.cabezaVR.rotation;
    }
}
