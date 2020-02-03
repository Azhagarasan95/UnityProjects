using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Rigidbody2D enemyRB;

	private void Start() {
		enemyRB = GetComponent<Rigidbody2D>();
		Destroy(gameObject, 20);
	}

	private void Update() {
		enemyRB.velocity = Vector2.down * 3;
	}

}
