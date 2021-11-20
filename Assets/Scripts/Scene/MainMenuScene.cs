using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScene : BaseScene
{
    public static MainMenuScene instance = null;

    public Canvas StartCanvas;
    public Canvas MapCanvas;

    private void Awake()
    {
        Init();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (StaticClass.MainMenuStatus == false) {
            StartCanvas.enabled = true;
            MapCanvas.enabled = false;
        }
        else
        {
            StartCanvas.enabled = false;
            MapCanvas.enabled = true;
        }
    }
    public override void Clear()
    {
    }
    public override void Init()
    {
        base.Init();
        Debug.Log("Start MainMenu");
    }
    public void StartScreen_Active()
    {
        StartCanvas.enabled = true;
        MapCanvas.enabled = false;
    }
    public void MapScreen_Active()
    {
        MapCanvas.enabled = true;
        StartCanvas.enabled = false;
    }
}
