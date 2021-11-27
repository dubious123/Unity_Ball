using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile_Start : MonoBehaviour
{
    [SerializeField] Transform _End;
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(0.5f, 0.5f, 0.5f));
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawLine(transform.position, _End.position);
    }
}
