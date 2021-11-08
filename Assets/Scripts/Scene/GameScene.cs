using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    [SerializeField] Ball _Ball;
    public override void Init()
    {
        base.Init();
        //Managers.GameMgr.CreatePlayer();

        //Managers.GameMgr.StartGame();
        Debug.Log("GameStart");
    }
    public override void Clear()
    {
    }
}
