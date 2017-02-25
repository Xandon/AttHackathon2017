using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

class Player : NetworkBehaviour
{
    [SyncVar]
    public int health = 100;

    Rigidbody rig;

    public GameObject bulletPrefab;
    private void Start()
    {
        try
        {
            rig = GetComponent<Rigidbody>();
        }
        catch
        {

        }
        
    }
    [Command]
    void CmdDoFire(float lifeTime)
    {
        print("FIRE");
        GameObject bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position + transform.right,
            Quaternion.identity);

        var bullet2D = bullet.GetComponent<Rigidbody>();
        bullet2D.velocity = transform.right * 100;
        Destroy(bullet, lifeTime);

        NetworkServer.Spawn(bullet);
    }

    void Update()
    {
        if (isClient)
        {
            Debugger.instance.DebugOut("Is client "  + "islocal " + isLocalPlayer + " " + NetworkManager.singleton.networkAddress + " " + Network.player.ipAddress);
        }
        if (isServer)
        {
            Debugger.instance.DebugOut("Is Server " + "islocal " + isLocalPlayer + " " + NetworkManager.singleton.networkAddress + " " + Network.player.ipAddress);
        }
        if (!isLocalPlayer)
            return;

        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(transform.forward * Time.deltaTime * 400);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(transform.forward * Time.deltaTime * -400);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdDoFire(3.0f);
            TakeDamage(25);
        }

    }



    

    [ClientRpc]
    void RpcDamage(int amount)
    {
        print("RPC Received" + amount);
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
            return;

        health -= amount;
        RpcDamage(amount);
    }
    
}