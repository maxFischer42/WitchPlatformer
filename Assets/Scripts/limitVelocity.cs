using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitVelocity : MonoBehaviour {

    public Rigidbody2D rigidbody;
    public float velocityLimit;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void LateUpdate () {
        Vector2 newVel;

        if (rigidbody.velocity.y > velocityLimit)
        {
            newVel = new Vector2(rigidbody.velocity.x, velocityLimit);
            rigidbody.velocity = newVel;
        }
        else if(rigidbody.velocity.y < (velocityLimit * -1))
        {
            newVel = new Vector2(rigidbody.velocity.x, velocityLimit * -1f);
            rigidbody.velocity = newVel;
        }

	}

}
