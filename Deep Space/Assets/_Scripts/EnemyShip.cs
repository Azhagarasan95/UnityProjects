using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

	public GameObject laser;
	public Transform laserSpawnPoint;

	public float currentHealth;
	public float maxHealth;

	[Range(2, 7.5f)]
	public float enemyDetectionRange = 5;
	public bool isChasingPlayer = false;

	int attackPower = 10;
	PlayerShip scriptPlayerShip;
	GameObject playerShip;
	int moveSpeed = 3;
	Vector3 facingDirection;

	private void Start() {
		attackPower = new System.Random().Next(10, 25);
		moveSpeed = new System.Random().Next(1, 5);
		scriptPlayerShip = FindObjectOfType<PlayerShip>();
		playerShip = FindObjectOfType<PlayerShip>().gameObject;
	}

	private void Update() {

		if(currentHealth <= 0) {
			Destroy(gameObject);
		}

		if(isChasingPlayer) {
			transform.position = Vector2.MoveTowards(transform.position, playerShip.transform.position, moveSpeed * Time.deltaTime);
			facingDirection = transform.position - playerShip.transform.position;
			float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

		}

		if(Vector2.Distance(playerShip.transform.position, transform.position) < 5) {
			isChasingPlayer = true;
			StartCoroutine(ShootAtPlayer());
		} else {
			isChasingPlayer = false;
			StopAllCoroutines();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.CompareTag("Player")) {
			currentHealth -= 5;
		}
		if(collision.gameObject.CompareTag("Player Laser")) {
			currentHealth -= scriptPlayerShip.laserPower;
		}
	}

	IEnumerator ShootAtPlayer() {
		while(true) {
			GameObject spawnedLaser = Instantiate(laser, laserSpawnPoint.position, Quaternion.identity);
			float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
			spawnedLaser.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			spawnedLaser.GetComponent<Rigidbody2D>().AddForce(facingDirection.normalized * 500);
			Destroy(spawnedLaser, 5);

			yield return new WaitForSeconds(3);
		}
	}

}
