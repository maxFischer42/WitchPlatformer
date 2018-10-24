using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPotion : MonoBehaviour {


    public Element[] element;
    public GameObject[] platform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            int i = 0;
            Element EnemyElement = collision.gameObject.GetComponent<Enemy>().element;
            if(EnemyElement == element[1])
            {
                i = 1;
            }

            GameObject plat = (GameObject)Instantiate(platform[i], transform.position, Quaternion.identity);
            plat.transform.parent = null;
            collision.gameObject.GetComponent<Enemy>().DestroyObject();
            Destroy(gameObject);
        }
    }

}
