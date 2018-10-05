using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feetDetection : MonoBehaviour
{

    private Controller player;
    private int layer;

    void Start()
    {
        player = transform.parent.GetComponent<Controller>();
        layer = player.groundLayer;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(layer == collision.gameObject.layer)
        {
            player.isGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (layer == collision.gameObject.layer)
        {
            player.isGrounded(false);
        }
    }


}
