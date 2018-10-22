using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPotion : MonoBehaviour {

    public GameObject platform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject plat = (GameObject)Instantiate(platform, transform.position, Quaternion.identity);
            plat.transform.parent = null;
            collision.gameObject.GetComponent<Enemy>().DestroyObject();
            Destroy(gameObject);
        }
    }

}
