using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(NetworkView))]
public class Server2 : MonoBehaviour {
    public bool isServer = true;
    NetworkView view;
    public string ipAddress = "";
	// Use this for initialization
	void Start () {
        view = GetComponent<NetworkView>();
        if (isServer)
        {
            Network.InitializeServer(10, 7777,false);
        }	else
        {
            Network.Connect(ipAddress);
        }        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
