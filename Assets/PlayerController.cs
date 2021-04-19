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
            rb.velocity = new Vector2(-5, 0);
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
