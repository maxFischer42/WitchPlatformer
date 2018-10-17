using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour {

    public Vector2 increment;
    public bool direction;
    SpriteRenderer PlayerRenderer;
    public GameObject Potion;
    public Vector2 velocity;

    public void Start()
    {
        PlayerRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ThrowPotion();
        }
    }

    public void ThrowPotion()
    {
        direction = PlayerRenderer.flipX;
        float flip = FlipA();
        Vector2 Spawn = new Vector2(transform.position.x + (increment.x + flip),transform.position.y + increment.y);
        GameObject newPotion = (GameObject)Instantiate(Potion, transform);
        newPotion.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * flip, velocity.y);
        newPotion.transform.parent = null;
    }

    float FlipA()
    {
        if (!PlayerRenderer.flipX)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }



}
