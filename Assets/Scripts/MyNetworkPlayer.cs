using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    private TMP_Text displayNameText = null;

    [SyncVar(hook = "HandleDisplayNameUpdate")]
    [SerializeField]
    private string displayName = "Missing Name";

    [SerializeField]
    private Renderer sphereColorRenderer = null;

    [SyncVar(hook = "HandleSphereColorUpdate")]
    [SerializeField]
    private Color sphereColor = new Color();

    [Server]
    public void SetDisplayNameTo(string aNewDisplayName)
    {
        if(aNewDisplayName.Contains("cheater"))
            return;
        displayName = aNewDisplayName;
        RpcClientsLog($"name: {aNewDisplayName}");
    }

    [Server]
    public void RandomizeSphereColor()
    {
        sphereColor = new Color(Random.Range(0f, 1f), 
                                Random.Range(0f, 1f), 
                                Random.Range(0f, 1f), 
                                Random.Range(0f, 1f));
    }

    [ClientRpc]
    private void RpcClientsLog(string aMessage)
    {
        Debug.Log($"Logging: {aMessage}");
    }

    [Command]
    private void CmdSetDisplayNameTo(string aNewDisplayName)
    {
        SetDisplayNameTo(aNewDisplayName);
    }

    [ContextMenu("Set Display Name")]
    private void SetMyName()
    {
        CmdSetDisplayNameTo("BlackCheater28");
    }

    private void HandleDisplayNameUpdate(string anOldDisplayName, string aNewDisplayName)
    {
        displayNameText.SetText(aNewDisplayName);
    }

    private void HandleSphereColorUpdate(Color anOldSphereColor, Color aNewSphereColor)
    {
        sphereColorRenderer.material.SetColor("_BaseColor", aNewSphereColor);
    }

}
