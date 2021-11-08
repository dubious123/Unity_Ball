using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Effect : MonoBehaviour
{
    [SerializeField] SpriteRenderer _Ball;
    [SerializeField] Ball_Death _Effect_Dead;
    public void PlayDeath()
    {
        _Effect_Dead.gameObject.SetActive(true);
        _Effect_Dead.Play(_Ball);
    }
}
