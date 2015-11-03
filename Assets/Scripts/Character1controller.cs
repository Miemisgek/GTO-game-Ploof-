using UnityEngine;
using System.Collections;

public class Character1controller : MonoBehaviour {
    //moving character left, right, jump
    //tutorial: www.youtube.com/watch?v=Xnyb2f6Qqzg 
    public float maxSpeed = 10f;
    bool facingRight = true;

   Animator anim;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 200f;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); // raak je een cirkel, aan is het ground?
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y); //hoe snel omhoog en hoe snel omlaag

        float move = Input.GetAxis("Horizontal");
        
        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        
        else if (move < 0 && facingRight)
            Flip();
	    }

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
    }

    // flip alles voor animatie
    void Flip()
    {
        // andere kant
        facingRight = !facingRight;
        // pak de local scale en position
        Vector3 theScale = transform.localScale;
        // flip it
        theScale.x *= -1;
        // maak dat de local scale
        transform.localScale = theScale;
    }

}
