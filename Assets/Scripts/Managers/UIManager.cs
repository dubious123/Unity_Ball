using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject GamePopup;
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        GamePopup = GameObject.FindGameObjectWithTag("PopupCanvas");
    }
    public void ShowPopup(GameObject popup)
    {
        Managers.ResourceMgr.Instantiate(popup, GamePopup.transform).name = popup.name;
    }
    public void HidePopup(GameObject original)
    {
        Managers.ResourceMgr.Destroy(GamePopup.transform.Find(original.name).gameObject);      
    }
    internal void Clear()
    {
        throw new NotImplementedException();
    }
}
