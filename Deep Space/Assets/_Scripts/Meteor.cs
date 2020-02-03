using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour {

	public int healthPoints = 100;
	public int damagePoints = 10;

	float angle;
	[Range(-2, 2)]
	public float rotationSpeed = 1;

	private void Start() {
		healthPoints *= (int) transform.localScale.x;
		damagePoints *= (int) transform.localScale.x;
		GetComponent<Rigidbody2D>().mass *= (int)transform.localScale.x;
	}

	private void Update() {
		angle += rotationSpeed;
		transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		if(healthPoints <= 0) {
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Player")) {
			if(TryGetComponent<PlayerShip>(out PlayerShip playerShip)) {
				playerShip.currentHealth -= damagePoints;
				Destroy(gameObject);
			}
		}

		if(collision.gameObject.CompareTag("Meteor")) {
			healthPoints -= collision.gameObject.GetComponent<Meteor>().damagePoints;
		}

		if(collision.gameObject.CompareTag("Player Laser")) {
			healthPoints -= 10;
			Destroy(collision.gameObject);
		}
	}


}
