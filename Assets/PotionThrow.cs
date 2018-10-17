using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionThrow : MonoBehaviour {

    public Vector2 increment;
    public bool direction;
    SpriteRenderer PlayerRenderer;
    public GameObject Potion;

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
        float flip = transform.position.x / Mathf.Abs(transform.position.x);
        Vector2 startPosition = transform.position;
        startPosition = new Vector2(startPosition.x + (flip * increment.x), startPosition.y + (increment.y));
        GameObject newPotion = (GameObject)Instantiate(Potion,transform);
        PotionUpdate potionUp;
        potionUp.startPosition = startPosition;
        potionUp.direction = flip;
        newPotion.GetComponent<PotionUpdate>() = potionUp;

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
