using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : limitVelocity {



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
        rigidbody.velocity = velocity;
        LimitVel();
    }

    void LimitVel()
    {
        Vector2 newVel = Vector2.zero;
        if (rigidbody.velocity.y > velocityLimit.y)
        {
            newVel = new Vector2(rigidbody.velocity.x, velocityLimit.y);
            rigidbody.velocity = newVel;
        }
        else if (rigidbody.velocity.y < (velocityLimit.y * -1))
        {
            newVel = new Vector2(rigidbody.velocity.x, velocityLimit.y * -1f);
            rigidbody.velocity = newVel;
        }

        if (rigidbody.velocity.x > velocityLimit.x)
        {
            newVel = new Vector2(velocityLimit.x, rigidbody.velocity.y);
            rigidbody.velocity = newVel;
        }
        else if (rigidbody.velocity.x < (velocityLimit.x * -1))
        {
            newVel = new Vector2(velocityLimit.x * -1f, rigidbody.velocity.y);
            rigidbody.velocity = newVel;
        }
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
            Debug.Log("Jumped");
            Jumped = true;
            animator.SetBool("Jumped", true);
            animator.SetBool("Grounded", false);
            animator.enabled = false;
            spriteRenderer.sprite = jumpSprite;
            velocity = new Vector2(rigidbody.velocity.x, jumpAcceleration * rigidbody.mass);
            return true;
        }
        animator.enabled = true;
        animator.SetBool("Jumped", false);
        return false;
    }

    void Falling()
    {
        if(rigidbody.velocity.y <= 0)
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
        Debug.Log("Move horizontal");
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
