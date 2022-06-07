using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string displayName = "Missing Name";

    [SyncVar]
    [SerializeField]
    private Color sphereColor = new Color();

    [Server]
    public void SetDisplayNameTo(string aNewDisplayName)
    {
        displayName = aNewDisplayName;
    }

    [Server]
    public void RandomizeSphereColor()
    {
        sphereColor = new Color(Random.Range(0, 255), 
                                            Random.Range(0, 255), 
                                            Random.Range(0, 255), 
                                            (float)Random.Range(0, 100)/100);
    }
}
