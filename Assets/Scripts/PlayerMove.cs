using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody2D rb;

    public Animator anim;
    public SpriteRenderer sr;




    public Vector2 moveVector;
    public float speed = 4f;
    public float fastSpeed = 6;
    private float realSpeed;


    public bool faceRight = true;

    public float jumpForce = 400f;


    public bool onGround;
    public static bool hasKey;//есть ли у персонажа ключ
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    private float GroundCheckRadius;

    public Transform TopCheck;
    private float TopCheckRadius;
    public LayerMask Roof;
    public Collider2D poseStand;
    public Collider2D poseSquat;
    private bool jumpLock = false;

    // public bool sunduk = false;


    public Key followingKey;
    public Transform keyFollowPoint;



    void Start()
    {
        //hasKey = false;

    Screen.SetResolution(800, 600, false);

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        GroundCheckRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        TopCheckRadius = TopCheck.GetComponent<CircleCollider2D>().radius;

        realSpeed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Run();
        Jump();
        Reflect();
        ChekingGround();
        SquatCheck();
        CheckingLadder();
        LaddersMechanics();
        LadderUpDown();
        LADDERS();
        CorrectLadder();
        //LadderCenter();

    }

    void Walk()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x* realSpeed, rb.velocity.y);
    }


    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //anim.
            realSpeed = fastSpeed;

        }

        else 
        {
            //anim
            realSpeed = speed;
        }

    }
 

    void Reflect() 
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
            {
            transform.localScale *= new Vector2(-1,1);
            faceRight = !faceRight;
            }
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !jumpLock && !onLadder)
        {
            //rb.velocity = new Vector2(rb.velocity.x,jumpForce);
            rb.AddForce(Vector2.up*jumpForce);
        }
    }



    void ChekingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }


    void SquatCheck()
    {
        if (Input.GetKey(KeyCode.X))
        {
            anim.SetBool("squat", true);
            poseStand.enabled = false;
            poseSquat.enabled = true;
            jumpLock = true;
        }

        else if (!Physics2D.OverlapCircle(TopCheck.position, TopCheckRadius, Roof))
        {
            anim.SetBool("squat", false);
            poseStand.enabled = true;
            poseSquat.enabled = false;
            jumpLock = false;
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Cristal"))
        {
            CristalCollect.cristalCount += 1;
            Destroy(collision.gameObject);
        }

        if (collision.tag.Equals("Key") && Ball.checkKorzina)
        { 
           hasKey = true;
           // Destroy(collision.gameObject);
       }

       

    }


    private void OnCollisionStay2d(Collision2D other)
    {
        //if (other.gameObject.name == "door" && hasKey) 
        //{

        //}
    }




    public float check_Radius = 0.04f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(Check_Ladder.position, check_Radius);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(bottom_Ladder.position, check_Radius);
    }

    public Transform Check_Ladder;
    public bool checkedLadder;
    public LayerMask LadderMask;
    public Transform bottom_Ladder;
    public bool bottomCheckedLadder;



    void CheckingLadder()
    {
        checkedLadder = Physics2D.OverlapPoint(Check_Ladder.position, LadderMask) ;
        bottomCheckedLadder = Physics2D.OverlapPoint(bottom_Ladder.position, LadderMask);
    }



   



    public float ladderSpeed = 0.5f;

    void LaddersMechanics()
    {
        if (onLadder) 
        { rb.bodyType = RigidbodyType2D.Kinematic;
            rb.velocity = new Vector2(rb.velocity.x, moveVector.y/ladderSpeed);
        }
        else { rb.bodyType = RigidbodyType2D.Dynamic; }
    }


    void LadderUpDown()
    {
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("moveY", moveVector.y);

    }

    float vertInput;
    public bool onLadder; //схватился ли персонаж за лестницу

    void LADDERS()
    {
        vertInput = Input.GetAxisRaw("Vertical");



        if (checkedLadder || bottomCheckedLadder)
        {
            if (!checkedLadder && bottomCheckedLadder) //персонаж сверху лестницы
            {
                if (vertInput > 0)      { onLadder = false; }
                else if (vertInput < 0) { onLadder = true; }

            }

            else if (checkedLadder && bottomCheckedLadder) //персонаж на лестнице
            {
                if (vertInput > 0)      { onLadder = true; }
                else if (vertInput < 0) { onLadder = true; }
            }

            else if (checkedLadder && !bottomCheckedLadder) //персонаж внизу лестницы

            {
                if (vertInput > 0)      { onLadder = true; }
                else if (vertInput < 0) { onLadder = false; }
            }

        }
        else { onLadder = false; }

        LaddersMechanics();

        anim.SetBool("onLadder", onLadder);
    }


    bool corrected = true;

    void CorrectLadder()
    {
        if (onLadder && corrected) { corrected = !corrected;}
        else if (!onLadder && !corrected) { corrected = true; }
    }

    //float ladderCenter;
    //void LadderCenter()
    //{ if (checkedLadder) { ladderCenter = Physics2D.OverlapPoint(Check_Ladder.position, LadderMask).GetComponent<BoxCollider2D>().bounds.center.x; }
        //ladderCenter = Physics2D.OverlapPoint(Check_Ladder.position, LadderMask).gameObject.transform.position.x; Debug.Log(ladderCenter); //далее узнаем х-координату цента обьекта, с которым пересеклась указанная нами точка - т.е. бирюзовая сфера
         
        //transform.position = new Vector2(ladderCenter, transform.position.y);

    //}
}
