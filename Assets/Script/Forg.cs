using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class represent to Enemy like your Forg 

public class Forg : Enemy
{

    [SerializeField] private float leftcap;
    [SerializeField] private float rightcap;

    [SerializeField] private float jumpLength = 10f;

    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;

    private bool facingLeft = true;
    private Collider2D coli;
    private Rigidbody2D rb;





    protected override void Start()
    {
        base.Start();
        coli = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {


        // transition from jump to fall
        if (anim.GetBool("Jumping"))
        {
            if (rb.velocity.y < .1)
            {
                anim.SetBool("Falling", true);
                anim.SetBool("Jumping", false);

            }
        }

        // trasition from fall to Idle
        if (coli.IsTouchingLayers(ground) && anim.GetBool("Falling"))
        {
            anim.SetBool("Falling", false);

        }

    }

    private void Move()
    {

        if (facingLeft)
        {

            // Test to the see if we are beyond the leftcap

            if (transform.position.x > leftcap)
            {

                //  make sure sprite is facing right location and if it is not. then face right direction
                if (transform.position.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                // Test to see if i am on the ground if so jump
                if (coli.IsTouchingLayers(ground))
                {
                    // jump
                    rb.velocity = new Vector2(-jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);
                }

            }
            else
            {
                facingLeft = false;
            }

            // if it is not, we are going to face right
        }

        else
        {

            if (transform.position.x < rightcap)
            {

                //  make sure sprite is facing right location and if it is not. then face right direction
                if (transform.position.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                // Test to see if i am on the ground if so jump
                if (coli.IsTouchingLayers(ground))
                {
                    // jump
                    rb.velocity = new Vector2(jumpLength, jumpHeight);
                    anim.SetBool("Jumping", true);

                }

            }
            else
            {
                facingLeft = true;
            }
        }
    }


}
