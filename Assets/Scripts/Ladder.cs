using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public bool lockInput = false;
    public float climbVelocity = 1f;
    public int layer;
    private Rigidbody2D playerRigidbody;
    private PlatformController _platform;
    private bool isColliding;

	// Use this for initialization
	void Start () {
        _platform = GameObject.FindObjectOfType<PlatformController>().GetComponent<PlatformController>();
        playerRigidbody = GameObject.FindObjectOfType<PlatformController>().GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isColliding)
        {
            if(Input.GetButtonDown("Jump"))
            {
                isColliding = false;
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
        {
            isColliding = false;
        }
    }




}
