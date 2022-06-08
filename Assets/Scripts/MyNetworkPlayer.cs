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

    [SyncVar(hook = "HandleDisplayNameUpdate")]
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
        sphereColor = new Color(Random.Range(0f, 1f), 
                                Random.Range(0f, 1f), 
                                Random.Range(0f, 1f), 
                                Random.Range(0f, 1f));
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
