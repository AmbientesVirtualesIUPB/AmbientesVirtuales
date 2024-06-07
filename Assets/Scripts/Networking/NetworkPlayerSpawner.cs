using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
//using Photon.Realtime;

public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    GameObject spawnedPlayer;
    public override void OnJoinedRoom()
    {
        print("Entró en una Room");
        base.OnJoinedRoom();
        spawnedPlayer = PhotonNetwork.Instantiate("Network Player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        print("Entró en una Room");
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayer);
    }

}
