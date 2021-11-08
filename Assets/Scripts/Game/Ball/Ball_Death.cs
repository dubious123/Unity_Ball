using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Death : MonoBehaviour
{
    public FMODUnity.EventReference _Death;
    public void Play(SpriteRenderer sr)
    {
        sr.sprite = null;
        FMODUnity.RuntimeManager.PlayOneShot(_Death, transform.position);
    }
    void EndPlay()
    {
        gameObject.SetActive(false);
    }
}
