using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConectarAlServidor();
    }

    void ConectarAlServidor()
    {
        PhotonNetwork.ConnectUsingSettings();
        print("Intentando conectar al servidor");
    }

    public override void OnConnectedToMaster()
    {
        print("Conectado al servidor");
        base.OnConnectedToMaster();
        ////////////////////////////////// Crear una habitación.
        RoomOptions rOpciones = new RoomOptions();
        rOpciones.MaxPlayers = 10;
        rOpciones.IsVisible = true;
        rOpciones.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room 1", rOpciones, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("Entró en una Room");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        print("Alguien estró en la Room");
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
