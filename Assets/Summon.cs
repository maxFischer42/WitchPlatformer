using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour {

    public float delay, delay2;
    public GameObject particlesDefault;
    public GameObject particlesSummon;
    public GameObject objectToSpawn;
    public GameObject spawnedObject;
    public Transform spawnLocation;

    private IEnumerator coroutine;
	
	// Update is called once per frame
	void Update () {
		if(!spawnedObject)
        {
            particlesDefault.SetActive(false);
            particlesSummon.SetActive(true);
            coroutine = WaitToSpawn(delay);
            StartCoroutine(coroutine);
            coroutine = StopParticles(delay2);
            StartCoroutine(coroutine);
        }
        if(spawnedObject)
        {
            coroutine = WaitToSpawn(delay);
            StopCoroutine(coroutine);
        }
	}

    IEnumerator WaitToSpawn(float del)
    {
        yield return new WaitForSeconds(del);
        if (!spawnedObject)
        {
            spawnedObject = (GameObject)Instantiate(objectToSpawn, spawnLocation);
            
        }
    }

    IEnumerator StopParticles(float del)
    {
        yield return new WaitForSeconds(del);
        if (spawnedObject)
        {
            particlesDefault.SetActive(true);
            particlesSummon.SetActive(false);
        }
    }
}
