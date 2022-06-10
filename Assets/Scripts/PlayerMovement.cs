using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private NavMeshAgent agent = null;

    [Command]
    public void CmdMoveTo(Vector3 aPosition)
    {
        agent.SetDestination(aPosition);
    }
}
