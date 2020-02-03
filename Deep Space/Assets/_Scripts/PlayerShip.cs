using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public float currentHealth = 100;
    public int maxHealth = 100;
    public float currentFuel = 100;
    public int maxFuel = 100;

    public ParticleSystem psStarField;
    public float moveSpeed = 5;
    public Transform laserSpawnPoint;
    public GameObject laser;
    public int laserPower = 15;
    public float spawnRate = 0.8f;

    Rigidbody2D playerShipRB;
    Vector3 facingDirection;
    GameManager scriptGameManager;

    private void Awake() {
        scriptGameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        playerShipRB = GetComponent<Rigidbody2D>();
        psStarField.Pause();
    }

    private void Update() {
        facingDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if(Input.GetMouseButtonDown(0)) {
            Shoot();
        }

        if(currentHealth <= 0) {
            scriptGameManager.isGameOver = true;
        }

    }

    private void FixedUpdate() {
        playerShipRB.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
        if(playerShipRB.velocity.magnitude != 0) {
            currentFuel -= 0.05f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Meteor")) {
            currentHealth -= collision.gameObject.GetComponent<Meteor>().damagePoints;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Black Hole")) {
            scriptGameManager.isGameFinished = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Fuel Station")) {
            currentFuel += 0.25f;
        }
        if(collision.gameObject.CompareTag("Base Station")) {
            currentHealth += 0.25f;
        }
    }

    void Shoot() {
        GameObject spawnedLaser = Instantiate(laser, laserSpawnPoint.position, Quaternion.identity);
        facingDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        spawnedLaser.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        spawnedLaser.GetComponent<Rigidbody2D>().AddForce(facingDirection.normalized * 500 / spawnRate);
        Destroy(spawnedLaser, 5);
    }

}
