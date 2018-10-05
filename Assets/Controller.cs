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






	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
	}
	

	void Update ()
    {
        Vector2 currentSpeed = Vector2.zero;
        if (midair)
            return;
        float x = GetX();
        x *= horizontalSpeed;
        float y = GetJump();
        y *= jumpAccel;
        if(x != 0)
        {
            currentSpeed = new Vector2(x, 0f);
        }
        if(y != 0)
        {
            currentSpeed = new Vector2(currentSpeed.x, y);
        }
        rigid.velocity = currentSpeed;
	}

    float GetX()
    {
        float x = Input.GetAxis("Horizontal");
        return x;
    }

    public void isGrounded(bool value)
    {
        midair = !value;
    }

    float GetJump()
    {
        float y = Input.GetAxis("Jump");
        return y;
    }

}
