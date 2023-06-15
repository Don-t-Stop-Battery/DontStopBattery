using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRaycast : MonoBehaviour
{
    [SerializeField]
    private Vector2 rayDir;
    private Vector2 shotPos;

    [SerializeField]
    private float distance, yPos;
    [SerializeField]
    private LayerMask layerMask;

    private void FixedUpdate()
    {
        shotPos = new Vector2(transform.position.x, transform.position.y - yPos);
    }
    public bool Shotray()
    {
        bool ishit= Physics2D.Raycast(transform.position,rayDir,distance,layerMask);
        return ishit;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawRay(shotPos, rayDir *distance);
    }
}
