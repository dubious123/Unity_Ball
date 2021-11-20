using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Boundary : MonoBehaviour
{
    [SerializeField] Transform _Ball;
    [SerializeField] int _Xmin;
    [SerializeField] int _Xmax;
    [SerializeField] int _Ymin;
    [SerializeField] int _Ymax;
    UnityEvent _checkingBall;
    Ball _me;
    Vector3 _pos;
    Vector3Int _nw;
    Vector3Int _ne;
    Vector3Int _se;
    Vector3Int _sw;
    private void Awake()
    {
        _checkingBall = new UnityEvent();
        _checkingBall.AddListener(CheckingBallPos);
        _me = _Ball.GetComponent<Ball>();
        _nw = new Vector3Int(_Xmin, _Ymax, 0);
        _ne = new Vector3Int(_Xmax, _Ymax, 0);
        _se = new Vector3Int(_Xmax, _Ymin, 0);
        _sw = new Vector3Int(_Xmin, _Ymin, 0);

    }
    private void Update()
    {
        _checkingBall.Invoke();
    }
    void CheckingBallPos()
    {
        _pos = _Ball.position;
        Debug.DrawLine(_nw, _ne, Color.green);
        Debug.DrawLine(_ne, _se, Color.green);
        Debug.DrawLine(_se, _sw, Color.green);  
        Debug.DrawLine(_sw, _nw, Color.green);
        if (_pos.x <= _Xmin || _pos.x >= _Xmax || _pos.y <= _Ymin || _pos.y >= _Ymax)
        {
            _me.PerformDeath();
            _checkingBall.RemoveAllListeners();
        }
    }
}
