using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTile : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
=======
        if (collision.gameObject == player)
        {
            Managers.ResourceMgr.Destroy(gameObject);
        }
>>>>>>> 534ec0762d355b54ff9cc32469f6777764f2e60e
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            Managers.ResourceMgr.Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        Managers.GameMgr.UpdateGoal();
    }
}
