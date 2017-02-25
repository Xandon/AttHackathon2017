using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NetworkView))]
public class NetworkClient : MonoBehaviour {
    NetworkView _view;


    public Transform cubePrefab;
    public NetworkView nView;
    // Use this for initialization
    void Start () {
        Network.Connect("127.0.0.1", 4444);
        _view = new NetworkView();
        // _view = GetComponent<NetworkView>();
        // print(_view.viewID);
        //_view.RPC("Bang", RPCMode.All);
        nView = GetComponent<NetworkView>();
        NetworkViewID viewID = Network.AllocateViewID();
        nView.RPC("SpawnBox", RPCMode.AllBuffered, viewID, transform.position);
    }
	
	void PingServer()
    {
        _view.RPC("Bang", RPCMode.All);
    }
    [RPC]
    void Bang()
    {
        print("Bang");
    }

    [RPC]
    void SpawnBox(NetworkViewID viewID, Vector3 location)
    {
        Transform clone;
        clone = Instantiate(cubePrefab, location, Quaternion.identity) as Transform as Transform;
        NetworkView nView;
        nView = clone.GetComponent<NetworkView>();
        nView.viewID = viewID;
    }
}
