using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMov : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 5f);

            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
