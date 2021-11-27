using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTile : BaseBlock
{
    Rigidbody2D _ball;
    [SerializeField] float _Jump; 
    private void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    public override void Perform()
    {
        _ball.velocity = new Vector2(_ball.velocity.x, _Jump);
    }
}
