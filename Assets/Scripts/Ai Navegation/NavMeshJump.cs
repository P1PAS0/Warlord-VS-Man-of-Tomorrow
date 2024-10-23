using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshJump : MonoBehaviour
{
    public bool isJumping = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void StartJump(Vector3 target, float jumpForce, float jumpDistance)
    {
        StartCoroutine(JumpTo(target, jumpForce, jumpDistance));
    }

    private IEnumerator JumpTo(Vector3 target, float jumpForce, float jumpDistance)
    {
        isJumping = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

        Vector3 jumpDirection = (target - transform.position).normalized;
        jumpDirection.y = 1; // A�ade componente vertical al salto

        rb.AddForce(jumpDirection * jumpForce, ForceMode.VelocityChange);

        yield return new WaitForSeconds(1f); // Espera hasta que el salto termine

        while (!IsGrounded())
        {
            yield return null;
        }

        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(target);
        isJumping = false;
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, 0.1f, LayerMask.GetMask("Ground"));
    }
}

