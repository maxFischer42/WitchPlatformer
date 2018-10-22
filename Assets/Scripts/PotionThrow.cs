using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour {

    public Vector2 increment;
    public bool direction;
    SpriteRenderer PlayerRenderer;
    public GameObject[] Potion;
    public Vector2 velocity;
    public Inventory m_inventory;

    public void Start()
    {
        PlayerRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        direction = PlayerRenderer.flipX;
        if (Input.GetButtonDown("Potion"))
        {
            ThrowPotion();
        }
    }

    public void ThrowPotion()
    {        
        float flip = FlipA();
        Vector2 Spawn = new Vector2(transform.position.x + (increment.x * flip),transform.position.y + increment.y);
        int a = 0;
        switch (m_inventory.currentPotion)
        {
            case 0:
                if (!(m_inventory.GreenPotions > 0))
                    return;
                m_inventory.GreenPotions--;
                break;
            case 1:
                if (!(m_inventory.RedPotions > 0))
                    return;
                a = 1;
                m_inventory.RedPotions--;
                break;
            case 2:
                if (!(m_inventory.PurplePotions > 0))
                    return;
                a = 2;
                m_inventory.PurplePotions--;
                break;
        }
        GameObject newPotion = (GameObject)Instantiate(Potion[a], Spawn, Quaternion.identity);
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
