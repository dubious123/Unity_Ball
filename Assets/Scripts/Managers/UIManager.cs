using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject _popupCanvas;
    GameObject PopupCanvas
    {
        get 
        {
            if (_popupCanvas == null) _popupCanvas = Managers.ResourceMgr.Instantiate(Managers.PrefabMgr.Popup_Canvas);
            return _popupCanvas; 
        } 
    }
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
    }
    public GameObject ShowPopup(GameObject popup)
    {
        GameObject go = Managers.ResourceMgr.Instantiate(popup, PopupCanvas.transform);
        go.name = popup.name;
        return go;
    }
    public void HidePopup(GameObject original)
    {
        Managers.ResourceMgr.Destroy(PopupCanvas.transform.Find(original.name).gameObject);      
    }
    public void ShowMenu()
    {
        ShowPopup(Managers.PrefabMgr.Popup_Menu);
        Managers.GameMgr.PauseGame();
        Managers.InputMgr._EscapeStartedEvent.RemoveAllListeners();
        Managers.InputMgr._EscapeCanceledEvent.AddListener(() =>
        {
            Managers.InputMgr._EscapeStartedEvent.AddListener(() => HidePopup(Managers.PrefabMgr.Popup_Menu));
            Managers.InputMgr._EscapeCanceledEvent.RemoveAllListeners();
        });
    }
    internal void Clear()
    {
        throw new NotImplementedException();
    }
}
