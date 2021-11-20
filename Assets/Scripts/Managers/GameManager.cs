using MEC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsPaused = false;
    int _starCount;
    float _currentStarCount;
    string _savePath;
    Progress _gameProgress;
    Goal _goal { get; set; }
    private void Awake()
    {
        Init();
    }
    public void Init()
    {
        _savePath = Application.persistentDataPath + "/Progress.json";
        if(File.Exists(_savePath)) File.Delete(_savePath);

    }
    public void StartGame()
    {
        _starCount = FindObjectOfType<Grid>().transform.GetChild(0).GetComponentsInChildren<CoinTile>().Length;
        _currentStarCount = _starCount;
        _goal = GameObject.FindGameObjectWithTag("Goal")?.GetComponent<Goal>();
    }
    public void PlayerDead()
    {
        Managers.UIMgr.ShowPopup(Managers.PrefabMgr.Popup_Restart);
        Managers.InputMgr._InteractionStartedEvent.AddListener(RestartLevel);
    }
    public void PlayerWin(int[] next)
    {
        UpdateProgress(next[0],next[1]);
        //StaticClass.CrossSceneInformation = "testtest";
        StaticClass.MainMenuStatus = true;
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        Managers.InputMgr._InteractionStartedEvent.RemoveAllListeners();
        Managers.UIMgr.HidePopup(Managers.PrefabMgr.Popup_Restart);
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Managers.InputMgr.EnableBallMove();
    }
    public bool CheckWinCondition()
    {
        return false;
    }
    public void UpdateGoal()
    {
        _currentStarCount--;
        _goal.UpdateGoal(1 - _currentStarCount / _starCount);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public IEnumerator<float> _ResumeGame(float waitTime)
    {
        yield return Timing.WaitUntilDone(_WaitForRealSeconds(waitTime).RunCoroutine());
        Time.timeScale = 1;
        yield break;
    }
    public IEnumerator<float> _WaitForRealSeconds(float waitTime)
    {
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < waitTime) yield return 0f;
        yield break;
    }
    public void UpdateProgress(int world, int map)
    {
        if (!File.Exists(_savePath))
        {
            File.WriteAllText(_savePath, JsonConvert.SerializeObject(new Progress()));
        }
        JObject jo = Managers.DataMgr.GetJObject(_savePath);
        jo["World"].Replace(world);
        jo["Map"].Replace(map);
        Debug.Log(jo);

        if (!File.Exists(_savePath))
        {
            File.WriteAllText(_savePath, JsonConvert.SerializeObject(new Progress()));
        }
        File.WriteAllText(_savePath, jo.ToString());
    }
    public Progress GetProgress()
    {
        _gameProgress = _gameProgress == null?  new Progress() : _gameProgress;
        if (!File.Exists(_savePath)) 
        {
            File.WriteAllText(_savePath, JsonConvert.SerializeObject(new Progress()));
        }
        Managers.DataMgr.PopulateObject(Managers.DataMgr.GetJson(_savePath), _gameProgress);
        return _gameProgress;
    }
    internal void Clear()
    {
    }
}
