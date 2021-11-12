using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    [SerializeField] Image _ProgressBar;
    [SerializeField] GameObject _Lock;
    [SerializeField] GameObject _UnLock;
    bool _winCondition = false;
    public void UpdateGoal(float percentage)
    {
        Debug.Log(percentage);
        _ProgressBar.fillAmount = percentage;
        if (percentage == 1)
        {
            _Lock.SetActive(false);
            _UnLock.SetActive(true);
            _winCondition = true;
        } 
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player" || !_winCondition) return;
        Managers.GameMgr.PlayerWin();
    }
}
