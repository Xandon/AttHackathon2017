using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
public class NewServer : NetworkManager {
    NetworkManager network;
    public GameObject VRRig;
    public GameObject AltCamera;

	// Use this for initialization
	void Start () {
        network = GetComponent<NetworkManager>();
        network.StartHost();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnConnectedToServer()
    {
        Debug.Log("Connected to server");
    }

    public override void OnServerConnect(NetworkConnection conn) {
        
        Debug.Log("OnServerConnected " + conn.connectionId);
    }

    public override void OnServerReady(NetworkConnection conn)
    {
        print("OnServerReady " + conn.address);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client Connected " + conn.connectionId);
        ClientScene.Ready(conn);
        ClientScene.AddPlayer(0);
    }

    // called when disconnected from a server
    public override void OnClientDisconnect(NetworkConnection conn)
    {
        StopClient();
    }
}



