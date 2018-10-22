using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {



    private Rigidbody2D rigidBody;
    public SpriteRenderer spriteRenderer;
    public float groundSpeed;
    public float jumpAcceleration;
    private Vector2 velocity;
    public Animator animator;
    public bool Grounded = false;
    public bool Jumped = false;

    public Sprite jumpSprite;
    public Sprite fallSprite;






	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
	}
	

	// Update is called once per frame
	void Update ()
    {
        
        if(!Grounded)
        {
            Falling();
            return;
        }
        if (!Jumping())
        {
            Move();
        }
        spriteRenderer.flipX = flipX();
        rigidBody.velocity = velocity;
    }

    bool Jumping()
    {
        if(Jumped || !Grounded)
        {
            animator.SetBool("Jumped", false);
            animator.enabled = false;
            spriteRenderer.sprite = fallSprite;
            return true;
        }
        if(Input.GetButtonDown("Jump"))
        {
            Jumped = true;
            animator.SetBool("Jumped", true);
            animator.SetBool("Grounded", false);
            animator.enabled = false;
            spriteRenderer.sprite = jumpSprite;
            velocity = new Vector2(rigidBody.velocity.x, jumpAcceleration * rigidBody.mass);
            return true;
        }
        animator.enabled = true;
        animator.SetBool("Jumped", false);
        return false;
    }

    void Falling()
    {
        if(rigidBody.velocity.y <= 0)
        {
            animator.SetBool("Jumped", false);
            animator.SetBool("falling", true);
            Jumped = false;
            spriteRenderer.sprite = fallSprite;
        }
    }



    float horizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    void Move()
    {
        
        float x = horizontalInput() * groundSpeed;
        if (x != 0)
        {
            animator.SetBool("isX", true);
        }
        else
        {
            x = 0f;
            animator.SetBool("isX", false);
        }
        velocity = new Vector2(x,0);
    }

    bool flipX()
    {
        if(velocity.x > 0)
        {
            return false;
        }
        else if(velocity.x == 0)
        {
            return spriteRenderer.flipX;
        }
        return true;
    }




}
