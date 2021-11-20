using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static bool IsAllSceneClosing { get { return _instance is null; } }
    public static Managers _instance;
    public static Managers Instance { get { Init(); return _instance; } }

    public GameManager _GameMgr;
    public PrefabManager _PrefabMgr;
    public ResourceManager _ResourceMgr;
    public UIManager _UIMgr;
    public PoolManager _PoolMgr;
    public CameraManager _CameraMgr;
    public InputManager _InputMgr;
    public DataManagers _DataMgr;

    public static GameManager GameMgr { get { return Instance._GameMgr; } }
    public static PrefabManager PrefabMgr { get { return Instance._PrefabMgr; } }
    public static ResourceManager ResourceMgr { get { return Instance._ResourceMgr; } }
    public static UIManager UIMgr { get { return Instance._UIMgr; } }
    public static PoolManager PoolMgr { get { return Instance._PoolMgr; } }
    public static CameraManager CameraMgr { get { return Instance._CameraMgr; } }
    public static InputManager InputMgr { get { return Instance._InputMgr; } }
    public static DataManagers DataMgr { get { return Instance._DataMgr; } }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    static void Init()
    {
        if (_instance != null) return;
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefabs/@Managers"));
        go.name = "@Managers";
        _instance = go.GetComponent<Managers>();
        _instance._GameMgr.Init();
        _instance._PrefabMgr.Init();
        _instance._ResourceMgr.Init();
        _instance._UIMgr.Init();
        _instance._PoolMgr.Init();
        _instance._CameraMgr.Init();
        _instance._InputMgr.Init();
        _instance._DataMgr.Init();
    }
    public static void Clear()
    {
        _instance._GameMgr.Clear();
        _instance._PrefabMgr.Clear();
        _instance._ResourceMgr.Clear();
        _instance._UIMgr.Clear();
        _instance._PoolMgr.Clear();
        _instance._CameraMgr.Clear();
        _instance._InputMgr.Clear();
        _instance._DataMgr.Clear();
        Timing.KillCoroutines();
        _instance = null;
    }
}
