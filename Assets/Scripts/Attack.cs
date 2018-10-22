using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Wand wand;
    private float cooldown;
    [HideInInspector] public bool onCooldown;
    private Vector2 direction;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        direction = new Vector2(1,0);
    }

    // Update is called once per frame
    void Update ()
    {
	    if(onCooldown)
        {
            cooldown += Time.deltaTime;
            if(cooldown >= wand.attackRate)
            {
                cooldown = 0f;
                onCooldown = false;
                anim.SetBool("Wand",false);
            }
            return;
        }
        else if(Input.GetButtonDown("Attack") && !onCooldown)
        {
            anim.SetBool("Wand", true);
            Vector2 velocity = direction;
            velocity = new Vector2(velocity.x * checkFlip() * wand.Speed, 0f);
            GameObject spawn = (GameObject)Instantiate(wand.prefabToSpawn, transform);
            spawn.GetComponent<Rigidbody2D>().velocity = velocity;
            spawn.transform.parent = null;
            Destroy(spawn, wand.timeTillDeSpawn);
            onCooldown = true;
        }
	}

    public void UpdateWand(Wand wand)
    {
        GetComponentInChildren<WandHealth>().ChangeWand();
    }

    float checkFlip()
    {
        if(GetComponent<SpriteRenderer>().flipX)
        {
            return -1;
        }
        return 1;
    }


}
