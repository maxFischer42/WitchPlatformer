using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushPlayer : MonoBehaviour {

    public Vector2 VelocityToPush;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Rigidbody2D>())
        {
            collision.GetComponent<Rigidbody2D>().AddForce(VelocityToPush);
            if(collision.name == "Player")
            {
                collision.GetComponent<PlatformController>().Grounded = false;
            }
        }
    }


}
