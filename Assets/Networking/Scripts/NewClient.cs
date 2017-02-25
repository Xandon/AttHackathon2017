using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NewClient : NetworkManager {
    NetworkManager network;
    public GameObject VRRig;
    public GameObject AltCamera;
    // Use this for initialization
    void Start () {
        network = GetComponent<NetworkManager>();
        network.StartClient();
	}

    private void OnConnectedToServer()
    {
        Debug.Log("Connected to server");
    }
}
