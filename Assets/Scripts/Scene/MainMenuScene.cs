using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScene : BaseScene
{
    public static MainMenuScene instance = null;

    public Canvas StartCanvas;
    public Canvas MapCanvas;
    public CanvasGroup StartScreen;
    public CanvasGroup MapScreen;

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
        DontDestroyOnLoad(gameObject);


        StartScreen.alpha = 1;
        StartCanvas.enabled = true;

        MapScreen.alpha = 0;
        MapCanvas.enabled = false;
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
        StartScreen.alpha = 1;
        StartScreen.interactable = true;
        StartCanvas.enabled = true;
        MapCanvas.enabled = false;
    }
    public void MapScreen_Active()
    {
        MapScreen.alpha = 1;
        MapScreen.interactable = true;
        MapCanvas.enabled = true;
        StartCanvas.enabled = false;
    }
}
