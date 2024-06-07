using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{
    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(interactor);
    }
}
