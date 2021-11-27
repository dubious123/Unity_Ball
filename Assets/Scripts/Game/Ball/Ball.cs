using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 _dir;
    [SerializeField] float _H_Speed;
    [SerializeField] float _V_Speed;
    [SerializeField] float _Bounce;
    [SerializeField] Rigidbody2D _RigidBody;
    [SerializeField] Ball_Effect _Effect;
    float _duration;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    GameObject downGo1;
    GameObject downGo2;
    GameObject downGo3;
    Color rayCol;
    private void Start()
    {
        rayCol = Color.red;
        _dir = new Vector3();
        Managers.InputMgr._OnRightPressedEvent.AddListener(()=>_dir += new Vector3(_V_Speed, 0));
        Managers.InputMgr._OnRightCanceledEvent.AddListener(() => _dir += new Vector3(-_V_Speed, 0));
        Managers.InputMgr._OnLeftPressedEvent.AddListener(() => _dir += new Vector3(-_V_Speed, 0));
        Managers.InputMgr._OnLeftCanceledEvent.AddListener(() => _dir += new Vector3(_V_Speed, 0));
    }
    private void FixedUpdate()
    {
        if(Mathf.Abs(_RigidBody.velocity.y)  <= 0.1f)  _duration += Time.deltaTime; 
        if(_duration > 0.15f)
        {
            _duration = 0;
            _RigidBody.velocity = new Vector2(_RigidBody.velocity.x, _Bounce);
        }
        hit = Physics2D.Raycast(transform.position, Vector2Int.down, 1f);
        hit2 = Physics2D.Raycast(transform.position + new Vector3(-0.175f,0), Vector2Int.down, 1f);
        hit3 = Physics2D.Raycast(transform.position + new Vector3(0.175f,0), Vector2Int.down, 1f);
        Debug.DrawRay(transform.position, Vector3Int.down , rayCol);
        Debug.DrawRay(transform.position + new Vector3(-0.175f, 0), Vector3Int.down , rayCol);
        Debug.DrawRay(transform.position + new Vector3(0.175f, 0), Vector3Int.down, rayCol);
        downGo1 = hit.collider == null? null :  hit.collider.gameObject;
        downGo2 = hit2.collider == null? null :  hit2.collider.gameObject;
        downGo3 = hit3.collider == null ? null : hit3.collider.gameObject;
        transform.Translate(_dir * Time.deltaTime * _H_Speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject != downGo1 && collision.gameObject != downGo2 && collision.gameObject != downGo3) || _RigidBody.velocity.y > 0) return;
        _RigidBody.velocity = new Vector2(_RigidBody.velocity.x, _Bounce);
        if (downGo1) { downGo1.GetComponent<BaseBlock>()?.Perform(); return; }
        if (downGo2) { downGo2.GetComponent<BaseBlock>()?.Perform(); return; }
        if (downGo3) { downGo3.GetComponent<BaseBlock>()?.Perform(); return; }
    }

    public void PerformDeath()
    {
        Managers.InputMgr.DisableBallMove();
        _RigidBody.gravityScale = 0f;
        _RigidBody.velocity = new Vector2(0f,0f);
        _Effect.PlayDeath();
        Managers.GameMgr.PlayerDead();
    }
    public bool IsAbove(Vector3 pos)
    {
        return transform.position.y >= pos.y + 0.5f && _RigidBody.velocity.y <= 0;
    }
}
