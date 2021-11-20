using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Btn_Map : MonoBehaviour
{
    [SerializeField] Button _Btn;
    [SerializeField] GameObject _Lock;
    [SerializeField] GameObject _UnLock;
    [SerializeField] TextMeshProUGUI _Text;
    void Start()
    {
        _Btn.onClick.AddListener(()=>SceneManager.LoadScene($"{SceneManager.GetActiveScene().name.Split(' ')[1]}-{transform.GetSiblingIndex() + 1}"));
    }
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
        _Text.text = (transform.GetSiblingIndex() + 1).ToString();
        _Btn.enabled = true;
    }
}
