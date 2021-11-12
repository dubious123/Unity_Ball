using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void BackBtn()
    {
        Debug.Log("back");
        MainMenuScene.instance.StartScreen_Active();
    }
}
