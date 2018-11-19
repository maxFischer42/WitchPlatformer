using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkByEnable : MonoBehaviour {

    public GameObject EnableObject;
    public bool m_switch; //this is what type of activation is set on the object (true, false)

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnableObject.SetActive(m_switch);
        }
    }
}
