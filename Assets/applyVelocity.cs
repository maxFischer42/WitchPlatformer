using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyVelocity : MonoBehaviour {

    public float mult = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>())
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity * mult;
        }
    }
}
