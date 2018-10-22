using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public float horizontalSpeed;
    public float jumpAccel;
    private Rigidbody2D rigid;
    public int groundLayer;
    public bool midair;
    public GameObject feetObject;
    public float gravityscale;
    public int groundlayer;
    public int walllayer;

    public bool walljump;
    private Vector2 storedVelocity;
    private float wallTimer;
    public float wallJumpTimer;







	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
	}
	

	void Update ()
    {
        
        midair = isGrounded();
        Vector2 currentSpeed = Vector2.zero;
        if (midair)
        {
            checkWallJump();
            downwardsVelocity();
            return;
        }
        float x = GetX();
        x *= horizontalSpeed;
        float y = GetJump();
        y *= jumpAccel;
        if(x != 0)
        {
            currentSpeed = new Vector2(x, 0f);
            rigid.velocity = currentSpeed;
        }
        if(y != 0)
        {
            currentSpeed = new Vector2(currentSpeed.x, y);
            rigid.AddForce(currentSpeed);
            storedVelocity = currentSpeed;
        }
        
	}

    float GetX()
    {
        float x = Input.GetAxis("Horizontal");
        return x;
    }

    public void downwardsVelocity()
    {
        if(rigid.velocity.y <= 0)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, -1 * gravityscale);
        }
    }

    public bool isGrounded()
    {
        if(rigid.velocity.y == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    float GetJump()
    {
        float y = Input.GetAxis("Jump");
        return y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == walllayer)
        {
            walljump = true;
        }
    }

    public void checkWallJump()
    {
        wallTimer += Time.deltaTime;
        if(Input.GetButtonDown("Jump"))
        {
            Vector2 newVel = storedVelocity;
            newVel = new Vector2(newVel.x * -1, newVel.y);
            rigid.AddForce(newVel);
            walljump = false;
        }
        if (wallTimer >= wallJumpTimer)
        {
            wallTimer = 0;
            walljump = false;
        }
    }

}
