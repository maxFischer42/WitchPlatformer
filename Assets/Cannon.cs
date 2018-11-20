using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    private Transform playerObject;
    [Range(1, 15)]
    public float rotationSpeed;
    [Range(1, 600)]
    public float projectileSpawnTimer;
    public float force;
    public GameObject projectile;
    public Transform spawn;
    private Rigidbody2D m_rigidbody;

    private float hiddenTimer = 0f;

    // Use this for initialization
    void Start() {
        m_rigidbody = GetComponent<Rigidbody2D>();
        playerObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() {
        Rotation();
        if(hiddenTimer >= projectileSpawnTimer)
        {
            hiddenTimer = 0f;
            GameObject obj = projectile;
            Vector2 direction = playerObject.position - transform.position;
            direction *= force;
            direction = new Vector2(direction.x, Mathf.Abs(direction.y * 25f));
            obj.GetComponent<Rigidbody2D>().velocity = direction;
            GameObject newObj = (GameObject)Instantiate(obj,spawn);
            newObj.transform.parent = null;
            Destroy(newObj, 4f);
        }
    }

    void Rotation()
    {
        hiddenTimer += Time.deltaTime;
        Vector2 direction = playerObject.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle > 240 || angle < -60 || (angle > 240 && angle < 300))
            return;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
    }
}
