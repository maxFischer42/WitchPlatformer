using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour {

    public Vector2 randomAttack;
    public Collider2D attackHitBox;
    public GameObject leftEmpty;
    public GameObject rightEmpty;
    public float goal;
    public float timer2 = 0;
    public float timer3 = 0;
    private bool attacking;
    private Animator anim;
    private Rigidbody2D m_rigidbody;
    private Enemy en;


	// Use this for initialization
	void Start ()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        goal = ResetTimer();
        anim = GetComponent<Animator>();
        en = GetComponent<Enemy>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        anim.SetBool("attack", attacking);

        

        if (attacking)
        {
            m_rigidbody.bodyType = RigidbodyType2D.Static;
            timer3 += Time.deltaTime;
            if(timer3 > 0.8f)
            {
                timer3 = 0;
                attacking = false;
                attackHitBox.enabled = false;
            }
            if(en.flipped < 0)
            {
                attackHitBox.transform.position = leftEmpty.transform.position;
                return;
            }
            attackHitBox.transform.position = rightEmpty.transform.position;
        }
        else
        {
            m_rigidbody.bodyType = RigidbodyType2D.Dynamic;
            timer2 += Time.deltaTime;
            if (timer2 >= goal)
            {
                attackHitBox.enabled = true;
                attacking = true;
                timer2 = 0;
                goal = ResetTimer();
            }
        }
	}

    float ResetTimer()
    {
        return Random.Range(randomAttack.x,randomAttack.y);
    }
}
