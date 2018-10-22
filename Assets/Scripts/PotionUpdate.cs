using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUpdate : MonoBehaviour {
    public int numberOfCollision = 2;
    public int[] collidableLayers;
    public int enemyLayer;

    public void Update()
    {
        if(numberOfCollision <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        for(int i = 0; i < collidableLayers.Length; i++)
        {
            if(collidableLayers[i] == collision.gameObject.layer)
            {
                numberOfCollision--;
                break;
            }

        }

    }


}
