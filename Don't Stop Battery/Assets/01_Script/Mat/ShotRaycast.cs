using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRaycast : MonoBehaviour
{
    [SerializeField]
    private Vector2 rayDir;
    [SerializeField]
    private float distance;
    [SerializeField]
    private LayerMask layerMask;

    private void Start()
    {
        rayDir.Normalize();
    }

    public bool ShotRay()
    {
        bool isHit = Physics2D.Raycast(transform.position, rayDir, distance, layerMask);

        return isHit;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawRay(transform.position, rayDir * distance);
    }
}
