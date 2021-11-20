using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : BaseBlock
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Perform()
    {
        //Debug.Log("ccc");
        player.GetComponent<Ball>().PerformDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Ball>().PerformDeath();
        }
    }


}
