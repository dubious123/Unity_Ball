using MEC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _H_Speed;
    [SerializeField] float _Bounce;
    [SerializeField] GUI _GUI;
    [SerializeField] Rigidbody2D _RigidBody;
    [SerializeField] Ball_Effect _Effect;
    RaycastHit2D hit;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    GameObject downGo;
    Color rayCol;
    private void Start()
    {
        rayCol = Color.red;
        Managers.InputMgr._OnRightPressedEvent.AddListener(()=>StartMoving(new Vector3(1,0)));
        Managers.InputMgr._OnRightCanceledEvent.AddListener(CancelMoving);
        Managers.InputMgr._OnLeftPressedEvent.AddListener(() => StartMoving(new Vector3(-1, 0)));
        Managers.InputMgr._OnLeftCanceledEvent.AddListener(CancelMoving);
    }
    private void FixedUpdate()
    {
        hit = Physics2D.Raycast(transform.position, Vector2Int.down, 1f);
        hit2 = Physics2D.Raycast(transform.position + new Vector3(-0.5f,0), Vector2Int.down, 1f);
        hit3 = Physics2D.Raycast(transform.position + new Vector3(0.5f,0), Vector2Int.down, 1f);
        Debug.DrawRay(transform.position, Vector3Int.down , rayCol);
        if (hit.collider != null) downGo = hit.collider.gameObject;
        else if (hit2.collider != null) downGo = hit2.collider.gameObject;
        else if (hit3.collider != null) downGo = hit3.collider.gameObject;
        else downGo = null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != downGo) return;
        _RigidBody.velocity = new Vector2(_RigidBody.velocity.x,_Bounce);
    }
    void StartMoving(Vector3 dir)
    {
        _GUI.enabled = true;
        _GUI.GUIEvent.AddListener(()=>Move(dir));
    }
    void CancelMoving()
    {
        _RigidBody.velocity = new Vector2(0, _RigidBody.velocity.y);
        _GUI.GUIEvent.RemoveAllListeners();
        _GUI.enabled = false;
    }
    void Move(Vector3 dir)
    {
        Vector3 delta = dir * Time.deltaTime * _H_Speed;
        transform.Translate(delta);
    }
    public void PerformDeath()
    {
        Managers.InputMgr.DisableBallMove();
        _RigidBody.gravityScale = 0f;
        _RigidBody.velocity = new Vector2(0f,0f);
        _Effect.PlayDeath();
        Managers.GameMgr.PlayerDead();
    }
}
