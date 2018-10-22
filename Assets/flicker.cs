using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker : MonoBehaviour {

    public Vector2 range;
    private Light m_light;

	// Use this for initialization
	void Start () {
        m_light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        float a = Random.Range(range.x, range.y);
        m_light.range = a;
        m_light.intensity = a;
	}
}
