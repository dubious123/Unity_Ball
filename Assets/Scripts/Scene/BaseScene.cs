using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class BaseScene : MonoBehaviour
{
    private void Start()
    {
        Init();
    }
    public virtual void Init()
    {
        Object obj = FindObjectOfType(typeof(EventSystem));
        if (obj == null)
        {
            Managers.ResourceMgr.Instantiate("UI/EventSystem").name = "@EventSystem";
        }
    }
    public abstract void Clear();
}
