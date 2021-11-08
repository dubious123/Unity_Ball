using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }
    public void Init()
    {

    }
    public void PlayerDead()
    {
        Managers.UIMgr.ShowPopup(Managers.PrefabMgr.Popup_Restart);
        Managers.InputMgr._InteractionStartedEvent.AddListener(RestartLevel);
    }
    public void RestartLevel()
    {
        Managers.InputMgr._InteractionStartedEvent.RemoveAllListeners();
        Managers.UIMgr.HidePopup(Managers.PrefabMgr.Popup_Restart);
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Managers.InputMgr.EnableBallMove();
    }

    internal void Clear()
    {
    }
}
