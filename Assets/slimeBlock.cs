using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeBlock : MonoBehaviour {

    public Vector2 VelocityToPush;
    private Animator anim;
    private float timer = 0;
    private bool shake;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Feet")
        {
            anim.enabled = true;
            if (Input.GetButtonDown("Jump"))
            {
                collision.transform.parent.GetComponent<Rigidbody2D>().AddForce(VelocityToPush * 3);
            }
            else
            {
                collision.transform.parent.GetComponent<Rigidbody2D>().AddForce(VelocityToPush * collision.transform.parent.GetComponent<Rigidbody2D>().velocity);
            }
                shake = true;
            timer = 0;
            if (collision.transform.parent.name == "Player")
            {
                collision.transform.parent.GetComponent<PlatformController>().Grounded = false;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (shake)
        {
            timer += Time.deltaTime;
            if (timer > 0.8f)
            {
                anim.enabled = false;
                shake = false;
                timer = 0;
            }
        }

	}
}
