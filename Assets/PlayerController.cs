using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //     float someNumber = 1.5f;
    //     int someholeNumber = 2;
    //     string babble = "Hello friends";
    //     bool fact = true;

    public Rigidbody2D rb;


    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
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
