using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;

	public AudioSource punchSound;
	public AudioSource baseJumpSound;
	public AudioSource doubleJumpSound;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    bool disableButtons = false;
    float disableDuration = 0.3f;

    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
	
	// Update is called once per frame
	void Update () {
        if (!disableButtons)
        {
			
            if (grounded)
            {
                doubleJumped = false;
            }
            // W (JUMP)
            if (Input.GetKeyDown(KeyCode.W) && grounded)
            {
				baseJumpSound.Play ();
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.W) && !doubleJumped && !grounded)
            {
				doubleJumpSound.Play ();
                anim.Play("Flip");
                Jump();
                doubleJumped = true;
                disableButtons = true;
                Invoke("EnableButtons", disableDuration);
            }

            // A (LEFT)
			if (Input.GetKey (KeyCode.A)) {
				anim.Play ("Running");
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			} 

            // D (RIGHT)
			if (Input.GetKey (KeyCode.D)) {
				anim.Play ("Running");
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			} 

            // SPACE (PUNCH)
            if (Input.GetKey(KeyCode.Space))
            {
                anim.Play("Punch");
                disableButtons = true;
				punchSound.Play ();
                Invoke("EnableButtons", disableDuration);
            }

            // ANIMATION HANDLING

            if (GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                transform.localScale = new Vector3(3f, 3f, 3f);
            }
            else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                transform.localScale = new Vector3(-3f, 3f, 3f);
            }
        }
	}

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }

    void EnableButtons()
    {
        disableButtons = false;
        anim.Play("Idle");
    }
		
}
