using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string displayName = "Missing Name";

    [Server]
    public void SetDisplayNameTo(string aNewDisplayName)
    {
        displayName = aNewDisplayName;
    }
}
