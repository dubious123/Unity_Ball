using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerTransform;
    public float moveSpeed;
    private float CameraX;
    private float CameraY;

    private void Awake()
    {
        Init();
    }
    public void Init()
    {
    }
    void Start()
    {
    }

    void Update()
    {
        if (player.gameObject != null)
        {

            CameraX = Mathf.Clamp(this.transform.position.x, player.transform.position.x - 3, player.transform.position.x + 3);
            CameraY = Mathf.Clamp(this.transform.position.y, player.transform.position.y - 3, player.transform.position.y + 3);
            this.transform.position = new Vector3(CameraX, CameraY , this.transform.position.z);
        }
    }

    internal void Clear()
    {
        throw new NotImplementedException();
    }
}
