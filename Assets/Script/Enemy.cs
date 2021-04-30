using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;

    protected virtual void Start()
    {

        anim = GetComponent<Animator>();

    }
    public void JumpedOn()
    {
        // Destroy(this.gameObject);

        anim.SetTrigger("Death");
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
