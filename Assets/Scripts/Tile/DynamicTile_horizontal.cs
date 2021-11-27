using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile_horizontal : MonoBehaviour
{
    Vector2 v;
    // Start is called before the first frame update
    void Start()
    {
        v = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(v * Time.deltaTime);
    }
}
