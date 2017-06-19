using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NetworkLauncher : Photon.PunBehaviour
{
    public PhotonLogLevel logLevel = PhotonLogLevel.Informational;
    public byte MaxPlayersPerRoom = 4;

    string _gameVersion = "0.1";


    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;

        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.logLevel = logLevel;
    }

    void Start()
    {
        ConnectToNetwork();
    }


    public void ConnectToNetwork()
    {
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
        }
    }

    public override void OnConnectedToMaster()
    {


        Debug.Log("DemoAnimator/Launcher: OnConnectedToMaster() was called by PUN");


    }


    public override void OnDisconnectedFromPhoton()
    {


        Debug.LogWarning("DemoAnimator/Launcher: OnDisconnectedFromPhoton() was called by PUN");
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("DemoAnimator/Launcher:OnPhotonRandomJoinFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");

        // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
        //PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = MaxPlayersPerRoom }, null);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("DemoAnimator/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }
}
