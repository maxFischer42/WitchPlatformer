using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    private Transform playerObject;
    [Range(1, 15)]
    public float rotationSpeed;
    [Range(1, 600)]
    public float projectileSpawnTimer;
    public GameObject projectile;
    private Rigidbody2D m_rigidbody;

    private float hiddenTimer = 0f;

    // Use this for initialization
    void Start() {
        m_rigidbody = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        projectileSpawnTimer += Time.deltaTime;
        Rotation();


    }

    void Rotation()
    {
        Vector2 direction = playerObject.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle > 240 || angle < -60 || (angle > 240 && angle < 300))
            return;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
