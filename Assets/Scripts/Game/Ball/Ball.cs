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
   
    RaycastHit2D hit;
    RaycastHit2D hit2;
    RaycastHit2D hit3;
    GameObject downGo;
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
        hit = Physics2D.Raycast(transform.position, Vector2Int.down, 1f);
        hit2 = Physics2D.Raycast(transform.position + new Vector3(-0.5f,0), Vector2Int.down, 1f);
        hit3 = Physics2D.Raycast(transform.position + new Vector3(0.5f,0), Vector2Int.down, 1f);
        Debug.DrawRay(transform.position, Vector3Int.down , rayCol);
        if (hit.collider != null) downGo = hit.collider.gameObject;
        else if (hit2.collider != null) downGo = hit2.collider.gameObject;
        else if (hit3.collider != null) downGo = hit3.collider.gameObject;
        else downGo = null;
        transform.Translate(_dir * Time.deltaTime * _H_Speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != downGo || _RigidBody.velocity.y > 0) return;
        _RigidBody.velocity = new Vector2(_RigidBody.velocity.x,_Bounce);
        downGo.GetComponent<BaseBlock>()?.Perform();
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
