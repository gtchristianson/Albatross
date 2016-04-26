using System;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float maxSpeed;
    public float ypsilon;
    public float upAngle;
    public float rightAngle;


    //jumpingvariables
    bool grounded = false;
    float groundCheckRadius = 0.05f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpForce;
    public float DX = (float)0, DY = (float)100;
    private static float radius = (float)100;
    private Vector2 up, right;

    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;

    public Camera zoomOut;
    bool camFlag; 


    // Use this for initialization
    void Start()
    {
        facingRight = true;
        up = Vector2.up;
        right = Vector2.right;
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        camFlag = false; 

    }

    void Update()
    {
        if (grounded && Input.GetAxis("Jump") > 0)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            //jumpforce
            myRB.AddForce(up*jumpForce);
        }


        if(Input.GetKeyUp(KeyCode.Z))
        {
            camFlag = !camFlag;
            zoomOut.enabled = camFlag; 
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 V = new Vector2(right.x * myRB.velocity.x + right.y * myRB.velocity.y, up.x * myRB.velocity.x + up.y * myRB.velocity.y);

        //check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalspeed", V.y);

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));

        if (grounded && Mathf.Abs(V.x) < maxSpeed)
        {
            myRB.velocity = right *move*maxSpeed+up*V.y;

            // if(move == 0)
            //{
            //  myRB.velocity = new Vector2(0, myRB.velocity.y);
            //}
            //myRB.AddForce(new Vector2(move * 10, myRB.velocity.y));       
        }

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        ForceUpright();

    }


    void ForceUpright()
    {
        float X, Y;
        Vector2 U = new Vector2(myRB.position.x - DX, myRB.position.y - DY);
        if (-radius / 4 <= U.y && U.y < radius / 4)
        {
            ypsilon = (float)(Math.Atan2(U.y, U.x) / Math.PI * 180);
        }
        else
        {
            ypsilon = (float)(Math.Atan2(U.y, 0) / Math.PI * 180);
        }
        X = (float)Math.Cos(ypsilon*Math.PI/180);
        Y = (float)Math.Sin(ypsilon*Math.PI/180);
        up = -(new Vector2(X, Y));
        right = new Vector2(-Y, X);


        upAngle = (float)(Math.Atan2(up.y, up.x) / Math.PI * 180);
        rightAngle = (float)(Math.Atan2(right.y, right.x) / Math.PI * 180);
       
        myRB.rotation = ypsilon + (float)90; 
    }


    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


}
