using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public bool requiresJump = false; // Indica si se necesita saltar
    public float jumpForce = 10f; // Fuerza del salto
    public float jumpDistance = 2f; // Distancia mínima para considerar un salto
}
