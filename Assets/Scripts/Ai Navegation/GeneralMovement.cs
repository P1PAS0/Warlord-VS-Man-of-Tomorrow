using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneralMovement : MonoBehaviour
{
    public Transform[] waypoints; // Array de waypoints
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

        // Verifica si el agente ha llegado al destino
        if (!agent.pathPending && agent.remainingDistance < 1f)
        {
            // Actualiza el índice del waypoint al siguiente
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

            // Verifica si el siguiente waypoint tiene configuraciones de salto
            Waypoint waypoint = waypoints[currentWaypointIndex].GetComponent<Waypoint>();
            if (waypoint != null && waypoint.requiresJump)
            {
                jumper.StartJump(waypoints[currentWaypointIndex].position, waypoint.jumpForce, waypoint.jumpDistance);
            }
            else
            {
                // Establece el nuevo destino
                agent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }
}

