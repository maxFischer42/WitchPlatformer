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
                collision.gameObject.GetComponent<Enemy>().DestroyObject();
            }
            if(EnemyElement == element[2])
            {
                i = 2;
                collision.gameObject.GetComponent<BirdFly>().DestroyObject(true);
            }
            GameObject plat = (GameObject)Instantiate(platform[i], transform.position, Quaternion.identity);
            plat.transform.parent = null;
            
            Destroy(gameObject);
        }
    }

}
