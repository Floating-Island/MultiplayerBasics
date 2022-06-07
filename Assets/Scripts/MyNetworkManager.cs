using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkManager : NetworkManager 
{
    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("I Connected to a server!");
    }
}
