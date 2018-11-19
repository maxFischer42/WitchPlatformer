using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeWand : MonoBehaviour {

    private Wand playerWand;
    public Attack playerAttack;
    public Wand NewWand;
    public Canvas backdrop;
    public Text[] playerWandStats;
    public Text[] newWandStats;
    public Sprite openSprite;
    private SpriteRenderer m_spriteRenderer;

    private void Start()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        playerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerWand = playerAttack.wand;
            playerWandStats[0].text = playerWand.name;
            playerWandStats[1].text = playerAttack.GetComponentInChildren<WandHealth>().health + " HP";
            playerWandStats[2].text = playerWand.attackRate + " Cast rate";
            playerWandStats[3].text = playerWand.Speed + " Speed";

            newWandStats[0].text = NewWand.name;
            newWandStats[1].text = NewWand.wandHealth + " HP";
            newWandStats[2].text = NewWand.attackRate + " Cast rate";
            newWandStats[3].text = NewWand.Speed + " Speed";
            backdrop.enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(Input.GetButtonDown("Vertical"))
            {
                playerAttack.wand = NewWand;
                playerAttack.UpdateWand(NewWand);
                m_spriteRenderer.sprite = openSprite;
                backdrop.enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            backdrop.enabled = false;
        }
    }
}
