using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour {

    public ParticleSystem psStarField;
    public float moveSpeed = 5;

    Rigidbody2D playerShipRB;
    Vector2 mousePosition;

    private void Awake() {
        playerShipRB = GetComponent<Rigidbody2D>();
        psStarField.Pause();
    }

    private void Update() {
        mousePosition = Input.mousePosition;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 45, Vector3.forward);



    }

    private void FixedUpdate() {
        playerShipRB.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
    }

}
