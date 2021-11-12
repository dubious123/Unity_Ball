using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEC;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        Managers.InputMgr._EscapeStartedEvent?.RemoveAllListeners();
        Managers.InputMgr._EscapeStartedEvent?.AddListener(() => 
        {
            Managers.UIMgr.ShowMenu();
        });
        _WaitFor3SecondsToResume().RunCoroutine();

    }
    IEnumerator<float> _WaitFor3SecondsToResume()
    {
        TextMeshProUGUI counter = Managers.UIMgr.ShowPopup(Managers.PrefabMgr.Popup_ResumeCounter).GetComponent<TextMeshProUGUI>();
        counter.text = "Resume Game In 3";
        Debug.Log(3);
        yield return Timing.WaitUntilDone(Managers.GameMgr._ResumeGame(1f).RunCoroutine());
        Managers.GameMgr.PauseGame();
        Debug.Log(2);
        counter.text = "Resume Game In 2";
        yield return Timing.WaitUntilDone(Managers.GameMgr._ResumeGame(1f).RunCoroutine());
        Managers.GameMgr.PauseGame();
        Debug.Log(1);
        counter.text = "Resume Game In 1";
        yield return Timing.WaitUntilDone(Managers.GameMgr._ResumeGame(1f).RunCoroutine());
        Managers.UIMgr.HidePopup(Managers.PrefabMgr.Popup_ResumeCounter);
        yield break;
    }
}
