using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour
{
    Vector2 v;
    // Start is called before the first frame update
    void Start()
    {
        v = Vector2.right * 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(v);
    }


}
