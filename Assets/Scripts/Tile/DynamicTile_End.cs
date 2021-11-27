using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile_End : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(0.5f,0.5f,0.5f));
    }
}
