using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandHealth : MonoBehaviour {

    private Attack attack;
    private int health;

    public GameObject notice;

    private Collider2D collide;

    private float multihit;
    private bool multihitting;

    [HideInInspector]public bool hasWand = true;

	void Start ()
    {
        collide = GetComponent<PolygonCollider2D>();
        attack = transform.parent.GetComponent<Attack>();
        health = attack.wand.wandHealth;
	}

    public void ChangeWand()
    {
        attack = transform.parent.GetComponent<Attack>();
        health = attack.wand.wandHealth;
    }

    void Update ()
    {
        collide.enabled = attack.onCooldown;
        if (hasWand)
        {
            if (multihitting)
            {
                multihit += Time.deltaTime;
                if (multihit >= 0.2f)
                {
                    multihit = 0f;
                    health--;
                    multihitting = false;
                }
            }

            if (health <= 0)
            {
                attack.wand = null;
                GameObject a = (GameObject)Instantiate(notice, transform);
                a.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
                hasWand = false;
                Destroy(a, 4.5f);
            }
        }


	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            health--;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            multihitting = true;
        }
    }


}
