using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour
{
    [SerializeField] Transform _Start;
    [SerializeField] Transform _End;
    [SerializeField] float _Speed;
    Vector3 _dir;
    bool _isMovingFoward = true;
    float _ratio;
    private void Update()
    {
        _ratio += Time.deltaTime;
        if (_isMovingFoward)
        {
            transform.position = Vector3.Lerp(_Start.position, _End.position, _ratio);
            if((transform.position - _End.position).magnitude <= 0.025f) 
            { 
                _isMovingFoward = false;
                _ratio = 0f;
                transform.position = _End.position;
            }
            return;
        }
        transform.position = Vector3.Lerp(_End.position, _Start.position, _ratio);
        if ((transform.position - _Start.position).magnitude <= 0.025f) 
        {
            _isMovingFoward = true;
            _ratio = 0f;
            transform.position = _Start.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<Ball>().PerformDeath();
        }
    }

}
