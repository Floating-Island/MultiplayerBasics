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
        float maxNavMeshDistance = 1f;

        if(NavMesh.SamplePosition(aPosition, out NavMeshHit aHit, maxNavMeshDistance, NavMesh.AllAreas))
        {
            agent.SetDestination(aHit.position);
        }
    }
}
