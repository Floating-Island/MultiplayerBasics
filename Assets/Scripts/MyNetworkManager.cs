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

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);
        
        int randomNumber = Random.Range(5000, 7653);
        MyNetworkPlayer clientPlayer = conn.identity.GetComponent<MyNetworkPlayer>();
        clientPlayer.SetDisplayNameTo($"FaintColt{randomNumber}");
        
        clientPlayer.RandomizeSphereColor();

        Debug.Log($"New Player Added!\n-Number of Players connected: {numPlayers}.");
    }
}
