using System;
using UnityEditor;
using UnityEngine;

namespace Halcyon.BT.Integrations.Pathlist
{
    public class PathPoint: MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Handles.Label(transform.position + Vector3.up, gameObject.name);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }
    }
}