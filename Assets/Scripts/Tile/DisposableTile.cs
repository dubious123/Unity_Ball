using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposableTile : BaseBlock
{
    GameObject player;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public override void Perform()
    {
        //anim.Play("Anim");
        //Managers.ResourceMgr.Destroy(gameObject);
        Destroy(gameObject, 10 * Time.deltaTime);

    }
    void EndPlay()
    {
        Managers.ResourceMgr.Destroy(gameObject);
        //Destroy(gameObject, 10 * Time.deltaTime);
    }
}
