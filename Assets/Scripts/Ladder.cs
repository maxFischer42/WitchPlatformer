using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float climbVelocity = 1f;
    public int layer;
    private Rigidbody2D playerRigidbody;
    private PlatformController _platform;
    private bool isColliding;
    private float gScale;
    private GameObject player;
    private GameObject collidingObject;

	// Use this for initialization
	void Start () {
        _platform = GameObject.FindObjectOfType<PlatformController>().GetComponent<PlatformController>();
        playerRigidbody = GameObject.FindObjectOfType<PlatformController>().GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isColliding)
        {
            if(Input.GetButtonDown("Jump"))
            {
                isColliding = false;
                if (collidingObject.gameObject.layer == layer)
                {
                    
                    collidingObject.GetComponent<Rigidbody2D>().gravityScale = gScale;
                    isColliding = false;
                    player.GetComponent<PlatformController>().enabled = true;
                    player.GetComponent<PlatformController>().Grounded = false;
                    player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, player.GetComponent<PlatformController>().jumpAcceleration));
                    collidingObject = null;
                }
                return;
            }
            float y = Input.GetAxisRaw("Vertical");
            y *= climbVelocity;
            playerRigidbody.velocity = new Vector2(0f,y);
            _platform.enabled = isColliding;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layer)
        {
            isColliding = true;
            collidingObject = collision.gameObject;
            gScale = collision.GetComponent<Rigidbody2D>().gravityScale;
            collision.GetComponent<Rigidbody2D>().gravityScale = 0;
            player.GetComponent<PlatformController>().enabled = false;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
        {
            
            collision.GetComponent<Rigidbody2D>().gravityScale = gScale;
            isColliding = false;
            player.GetComponent<PlatformController>().enabled = true;
            player.GetComponent<PlatformController>().Grounded = false;
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,player.GetComponent<PlatformController>().jumpAcceleration));
            collidingObject = null;
        }
    }




}
