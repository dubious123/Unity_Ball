using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Ball _Ball;
    public override void Init()
    {
        base.Init();
        Debug.Log("GameStart");
    }
    public override void Clear()
    {
    }
}
