using UnityEngine;
using System.Collections;

public class Character1controller : MonoBehaviour {
    //moving character left, right, jump
    //tutorial: www.youtube.com/watch?v=Xnyb2f6Qqzg 
    public float maxSpeed = 10f;
    bool facingRight = true;

    Animator anim;

    bool grounded = false;
    GameObject hasObject;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 200f;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround); // raak je een cirkel, aan is het ground?
        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y); //hoe snel omhoog en hoe snel omlaag

        float move = Input.GetAxis("Horizontal"); //naar links en rechts bewegen

        anim.SetFloat("Speed", Mathf.Abs(move));

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y); //snelheid van het karakter

        if (move > 0 && !facingRight)
        {
            Flip();
        }

        else if (move < 0 && facingRight)
            Flip();
    }

    void Update()
    {
        // springen als je op spatie drukt en op de grond staat 
        if (grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if (hasObject != null && Input.GetKeyDown(KeyCode.DownArrow))
        {
            dropObject();
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

    public bool setHasObject(GameObject theObject)
    {
        // check of je een object vast hebt en vast zetten aan speler ja of nee
        if (!hasObject)
        {
            theObject.transform.parent = transform;
            theObject.transform.position = transform.GetComponentInChildren<playerHands>().transform.position;
            Destroy(theObject.GetComponent<Rigidbody2D>());
            hasObject = theObject;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void dropObject()
    {
        if (hasObject)
        {
            hasObject.AddComponent<Rigidbody2D>();
            hasObject.layer = LayerMask.NameToLayer("tower");
            hasObject.transform.parent = null;
            hasObject = null;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("flag"))
        {
            Debug.Log("YOU WIN: Loading menu in 4 seconds");
            StartCoroutine(LoadMenu());
        }
    }

    private IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel("mainScene");
    }
}
