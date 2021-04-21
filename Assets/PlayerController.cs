using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //     float someNumber = 1.5f;
    //     int someholeNumber = 2;
    //     string babble = "Hello friends";
    //     bool fact = true;

    private Rigidbody2D rb;
    [SerializeField]
    private Animator anim;
    private enum State { idle, running, jumping, falling }
    private State state = State.idle;
    private Collider2D coli;
    [SerializeField] private LayerMask ground;


    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coli = GetComponent<Collider2D>();
    }
    private void Update()
    {
        float hDirection = Input.GetAxis("Horizontal");


        // if (Input.GetKey(KeyCode.A))
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            // anim.SetBool("running", true);
        }

        // if (Input.GetKey(KeyCode.D))
        if (hDirection > 0)
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            // anim.SetBool("running", true);

        }

        else
        {
            // anim.SetBool("running", false);

        }

        if (Input.GetButtonDown("Jump") && coli.IsTouchingLayers(ground))
        {
            rb.velocity = new Vector2(rb.velocity.x, 8f);
            state = State.jumping;
        }

        velocityState();
        anim.SetInteger("state", (int)state);
    }

    private void velocityState()
    {
        if (state == State.jumping)
        {

            if (rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }

        else if (state == State.falling)
        {
            if (coli.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2F)
        {
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }




    // private void  Start()
    // {

    //     if(fact == true)
    //     {
    //         print(babble + "someNumber: " + someNumber.ToString() + "someholeNumber: " + someholeNumber.ToString() );
    //     }
    // }




}
