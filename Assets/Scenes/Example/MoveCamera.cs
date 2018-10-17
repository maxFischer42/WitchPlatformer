using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	private float spd = 1f;
    public Rigidbody2D Player;

	void Update() {
		Vector2 v = new Vector2(Player.velocity.x * spd, Player.velocity.y * spd);

		transform.Translate(v * Time.deltaTime);
	}
}
