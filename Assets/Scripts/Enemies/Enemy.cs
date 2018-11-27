using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Items[] drops;

    public Element element;
    public Element weakness;
    public Vector2 direction;
    private Vector2 startPosition;
    public float timer;
    private float timerIncrement;
    [HideInInspector]public float flipped = 1;
    public Rigidbody2D m_rigidBody;
    [HideInInspector] public SpriteRenderer sprite;
    public float speed;
    public GameObject deathEffect;

    public int health;

    public bool command;

    [HideInInspector] public Inventory playerInventory;

    


    // Use this for initialization
    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        playerInventory = GameObject.FindObjectOfType<Inventory>().GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        timerIncrement += Time.deltaTime;
        m_rigidBody.velocity = new Vector2(speed * flipped, 0f);
        if (timerIncrement >= timer)
        {
            flipped = flip(flipped);
        }
        if(command)
        {
            DestroyObject();
        }
    }

    float flip(float m_float)
    {
        sprite.flipX = !sprite.flipX;
        timerIncrement = 0f;
        return m_float * -1;
    }

    public void DestroyObject()
    {
        GameObject effect = deathEffect;
        effect = (GameObject)Instantiate(effect, transform);
        effect.transform.parent = null;
        GiveItems();
        Destroy(gameObject,0.1f);
    }

    public void GiveItems()
    {
        if (!(drops.Length < 1))
        {
            int random = Random.Range(0, drops.Length - 1);
            playerInventory.AddItem(drops[random]);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Magic")
        {
            int damage = 1;
            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>().wand.magicEffect == weakness)
            {
                damage *= 2;
            }
            else if(GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>().wand.magicEffect == element)
            {
                damage = 0;
            }
            health -= damage;
            
            GameObject effect = deathEffect;
            effect = (GameObject)Instantiate(effect, transform);
            effect.transform.parent = null;

            if(health <= 0)
            {
                DestroyObject();
            }
        }
    }


}
