using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class DoorwayScript : MonoBehaviour {

    private Transform exit;


	// Use this for initialization
	void Start () {
        exit = transform.GetChild(0).transform;
        GetComponent<BoxCollider2D>().isTrigger = true;
	}



    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Input.GetButtonDown("Vertical"))
        {
            collision.gameObject.transform.SetPositionAndRotation(exit.position, Quaternion.identity);
        }
    }



}
