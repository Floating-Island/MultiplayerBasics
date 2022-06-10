using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyPlayerMovement : NetworkBehaviour
{
    [SerializeField]
    private NavMeshAgent agent = null;

    [SerializeField]
    private Camera mainCamera = null;

    [Command]
    public void CmdMoveTo(Vector3 aPosition)
    {
        float maxNavMeshDistance = 1f;

        if(NavMesh.SamplePosition(aPosition, out NavMeshHit aHit, maxNavMeshDistance, NavMesh.AllAreas))
        {
            agent.SetDestination(aHit.position);
        }
    }
 
    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        mainCamera = Camera.main;
    }

    [ClientCallback]
    private void Update()
    {
        int leftMouseButtonNumber = 0;//0: left, 1: right, 2: middle
        if(hasAuthority && Input.GetMouseButtonDown(leftMouseButtonNumber))
        {
            Ray godRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(godRay, out RaycastHit godTouch, Mathf.Infinity))
            {
                CmdMoveTo(godTouch.point);
            }
        }
    }
}
