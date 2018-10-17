using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUpdate : MonoBehaviour {

    public Vector2 startPosition;
    public float direction;
    public float timerIncrement;
    float timer;
    Vector2 currentPos;

    private void Awake()
    {
        timerIncrement *= direction;
    }

    // Update is called once per frame
    void Update ()
    {
        timer += timerIncrement;
        float y = (-1 * Mathf.Pow(timer,2)) + (4 * timer) + -2;
        Vector2 newPosition = new Vector2(startPosition.x + timer,startPosition.y + y);
        transform.SetPositionAndRotation(newPosition,Quaternion.identity);
	}
}
