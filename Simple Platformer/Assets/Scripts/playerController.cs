using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {


    public float maxSpeed;


    //jumpingvariables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight; 


    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight; 

	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>(); 
        myAnim = GetComponent<Animator>() ;
        facingRight = true;     
	
	}

    void Update()
    {
        if(grounded && Input.GetAxis("Jump")>0)
        {
            grounded = false; 
            myAnim.SetBool("isGrounded", grounded);
            //jumpforce
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);

        myAnim.SetFloat("verticalSpeed", myRB.velocity.y); 

        float move = Input.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        
        if (grounded && Mathf.Abs(myRB.velocity.x) < maxSpeed)
        {
           myRB.velocity = new Vector2(move * maxSpeed, myRB.velocity.y);
            
           // if(move == 0)
            //{
              //  myRB.velocity = new Vector2(0, myRB.velocity.y);
            //}
            //myRB.AddForce(new Vector2(move * 10, myRB.velocity.y));       
        }
	
        if(move > 0 && !facingRight)
        {
            flip();    
        }
        else if (move < 0 && facingRight)
        {
            flip(); 
        }
    
	}


    void flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale; 
    }

}
