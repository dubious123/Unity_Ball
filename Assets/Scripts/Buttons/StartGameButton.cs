using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void StartBtn()
    {
        Debug.Log("pressed");
        //SceneManager.LoadScene("GameScene");
        MainMenuScene.instance.MapScreen_Active();
        
    }
}
