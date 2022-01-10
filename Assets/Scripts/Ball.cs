using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]

    /* public bool checkBall = false;

     public Rigidbody2D ball_rb;
     public Animator ball_anim;
     public Vector2 ball_moveVector;
     public float ball_speed = 5f;
     public Animator animBall;*/

    public static bool checkKorzina = false;

    // Start is called before the first frame update
    void Start()
    {

        //ball_moveVector =Input. ;

        //ball_rb = GetComponent<Rigidbody2D>();
       // ball_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //BallRun();
    }



    void BallRun() 
    {


        //animBall.SetBool("_ball", true);


        //if (checkBall)
        //{
        // ball_rb.velocity = new Vector2(ball_moveVector.x * ball_speed, ball_rb.velocity.y);
        //}
    }


     private void OnTriggerEnter2D(Collider2D collision)
     {
         //if (collision.tag.Equals("Player"))
         //{
            // checkBall = true;
        // }

            if (collision.gameObject.tag.Equals("Korzina"))
        {
            checkKorzina = true;
        }


     }

     /*private void OnTriggerExit2D(Collider2D collision)
     {
         checkBall = false;
     }*/


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.tag == "Player")
        //{
        //checkBall = true;
        //}

        //if (collision.gameObject.tag.Equals("Korzina"))
        //{
           // checkKorzina = true;
        //}

    //}
//
    private void OnCollisionExit2D(Collision2D collision)
    {
        //checkBall = false;
    }
 

}
