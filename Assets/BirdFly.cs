using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : Enemy {

    // private Rigidbody2D rigidBody;
    private Vector2 Spawn;
    public float timeUnitlVanish;
    private float timer2;
    private GameObject thisObject;

	// Use this for initialization
	void Start () {
        Spawn = transform.position;
        thisObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        timer2 += Time.deltaTime;
        if(timer2 >= timeUnitlVanish)
        {
            Instantiate(thisObject, Spawn, Quaternion.identity);
            Destroy(gameObject);
        }
        m_rigidBody.velocity = direction;
        if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
	}
}
