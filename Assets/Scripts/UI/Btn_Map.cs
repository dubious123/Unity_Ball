using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Btn_Map : MonoBehaviour
{
    [SerializeField] Button _Btn;
    [SerializeField] GameObject _Lock;
    [SerializeField] GameObject _UnLock;
    public void Lock()
    {
        _Lock.SetActive(true);
        _UnLock.SetActive(false);
        _Btn.enabled = false;
    }
    public void UnLock()
    {
        _Lock.SetActive(false);
        _UnLock.SetActive(true);
        _Btn.enabled = true;
    }
}
