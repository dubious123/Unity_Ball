using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelection : MonoBehaviour
{
    public int _MapNum;
    public int World;
    [SerializeField] GameObject _grid;
    Btn_Map[] _maps;
    public void Start()
    {
        _maps = _grid.GetComponentsInChildren<Btn_Map>();
        Progress pg = Managers.GameMgr.GetProgress();
        if(pg.World > World) { EnableAll(); }
        else if(pg.World < World) { DisableAll(); }
        else { OpenMaps(pg.Map); }
    }
    public void EnableAll()
    {
        OpenMaps(_MapNum);
    }
    public void DisableAll()
    {
        OpenMaps(0);
    }
    public void OpenMaps(int num)
    {
        for (int i = 0; i < num; i++) 
        {
            _maps[i].UnLock();
        }
        for(int i = num; i < _MapNum; i++)
        {
            _maps[i].Lock();
        }
    }
    public void Goto(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
