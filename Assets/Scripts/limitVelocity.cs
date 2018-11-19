using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitVelocity : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public Vector2 velocityLimit;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void LateUpdate () {
        Vector2 newVel;

        if (rigidbody.velocity.y > velocityLimit.y)
        {
            newVel = new Vector2(rigidbody.velocity.x, velocityLimit.y);
            rigidbody.velocity = newVel;
        }
        else if(rigidbody.velocity.y < (velocityLimit.y * -1))
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

}
