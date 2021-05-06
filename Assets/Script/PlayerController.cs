using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class represent to Entity like your player 
public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Collider2D coli;
    private Animator anim;
    public int cherries = 0;


    private enum State { idle, running, jumping, falling, hurt }
    private State state = State.idle;


    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 10f;
    [SerializeField] private Text CherryText;
    [SerializeField] private float hurtforce = 10f;
    [SerializeField] private AudioSource cherry;
    [SerializeField] private AudioSource footstep;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coli = GetComponent<Collider2D>();

    }



    private void Update()
    {
        if (state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable")
        {
            cherry.Play();
            Destroy(collision.gameObject);
            cherries += 1;
            CherryText.text = cherries.ToString();
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (state == State.falling)
            {
                // Destroy(other.gameObject);
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                state = State.hurt;
                if (other.gameObject.transform.position.x > transform.position.x)
                {
                    // Enemy is to my right therefore I should be damaged and move left
                    rb.velocity = new Vector2(-hurtforce, rb.velocity.y);
                }
                else
                {
                    // Enemy is to my left therefore I should be damaged and move right
                    rb.velocity = new Vector2(hurtforce, rb.velocity.y);

                }
            }

        }

    }

    private void Movement()
    {
        float hDirection = Input.GetAxis("Horizontal");

        // moving left
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        // moving right
        if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        // jumping
        if (Input.GetButtonDown("Jump") && coli.IsTouchingLayers(ground))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        state = State.jumping;
    }

    private void AnimationState()
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
        else if (state == State.hurt)
        {
            if (Mathf.Abs(rb.velocity.x) < .1f)
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

    private void FootStep()
    {
        footstep.Play();
    }
}
