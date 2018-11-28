using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour {

    public float decayTimer;
    private float timer;
    public GameObject decayObject;
    public float timeToDestroy;
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= decayTimer)
        {
            GameObject newPlat = (GameObject)Instantiate(decayObject,transform);
            newPlat.transform.parent = null;
            Destroy(newPlat, timeToDestroy);
            Destroy(gameObject);
        }
	}
}
