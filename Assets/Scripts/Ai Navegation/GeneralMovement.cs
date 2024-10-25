using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralMovement : MonoBehaviour
{
    public Transform[] waypoints; 
    private int currentWaypointIndex = 0;
    private NavMeshAgent agent;
    private NavMeshJump jumper;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        jumper = GetComponent<NavMeshJump>();

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        if (jumper.isJumping) return;

       
        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

          
            Waypoint waypoint = waypoints[currentWaypointIndex].GetComponent<Waypoint>();
            if (waypoint != null && waypoint.requiresJump)
            {
                jumper.StartJump(waypoints[currentWaypointIndex].position, waypoint.jumpForce, waypoint.jumpDistance);
            }
            else
            {
                
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }
}

