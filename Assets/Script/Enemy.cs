﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    protected Animator anim;
    protected Rigidbody2D rb;


    protected virtual void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();


    }
    public void JumpedOn()
    {
        // Destroy(this.gameObject);

        anim.SetTrigger("Death");
        rb.velocity = new Vector2(0, 0);
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
