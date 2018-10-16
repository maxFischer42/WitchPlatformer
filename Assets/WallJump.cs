using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour {

    public PlatformController player;
    public int WallLayer;
    public Vector2 force;

    public float timerObj;
    private float timer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == WallLayer)
        {
            timer += Time.deltaTime;
            if (timer <= timerObj)
            {

                if(Input.GetAxisRaw("Horizontal") < 0)
                {
                    player.spriteRenderer.flipX = true;
                }
                else
                {
                    player.spriteRenderer.flipX = false;
                }



                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                    timer = 0;
                }
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == WallLayer)
        {
            timer += Time.deltaTime;
            if (timer <= timerObj)
            {
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    player.spriteRenderer.flipX = true;
                }
                else
                {
                    player.spriteRenderer.flipX = false;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                    timer = 0;
                }
            }
            else
            {
                timer = 0;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == WallLayer)
        {
            timer = 0;
        }
    }

    void Jump()
    {
        Vector2 direction = force;
        if(!player.spriteRenderer.flipX)
        {
            direction = new Vector2(force.x * -1, force.y);
        }
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().velocity = direction;
    }

}
