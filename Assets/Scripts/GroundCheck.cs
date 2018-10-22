using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public PlatformController platformController;
    public int groundLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(groundLayer == collision.gameObject.layer)
        {
            platformController.animator.SetBool("Grounded", true);
            platformController.animator.SetBool("falling", false);
            platformController.Grounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (groundLayer == collision.gameObject.layer)
        {
            platformController.animator.SetBool("Grounded", true);
            platformController.animator.SetBool("falling", false);
            platformController.Grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (groundLayer == collision.gameObject.layer)
        {
            platformController.animator.SetBool("Grounded", false);
            platformController.Grounded = false;
        }
    }


}
