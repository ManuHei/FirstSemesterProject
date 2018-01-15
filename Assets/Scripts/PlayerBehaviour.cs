using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

    public float MovementSpeed;
    public Camera Cam;

    private float horizontalInput;
    private float verticalInput;

    private void Update() {
        getInput();
        cameraFollow();
    }

    private void getInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void cameraFollow() {
        Cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Cam.transform.position.z);
    }

    //Player wird von Trigger berührt
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            wirdWeggestoßen(collision);
        }
    }

    //Spieler wird weggestoßen
    private void wirdWeggestoßen (Collider2D collision)
    {
        EnemyBehaviour enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
        Vector2 direction = enemy.direction;

        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction*5, ForceMode2D.Impulse);
    }





    private void FixedUpdate() {
        //move();
        moveGleichschnell();
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    //Player bewegt sich diagonal schneller
    private void move() {
        float xMovement = horizontalInput * Time.deltaTime * MovementSpeed;
        float yMovement = verticalInput * Time.deltaTime * MovementSpeed;

        transform.Translate(new Vector3(xMovement, yMovement, transform.position.z));
    }

    //Player bewegt sich auch diagonal mit der gleichen Geschwindigkeit
    private void moveGleichschnell()
    {

        //Richtungsvektor erstellen
        Vector2 direction = new Vector2 (horizontalInput, verticalInput);
        //Vektor normieren (auf Länge 1 bringen)
        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * MovementSpeed);
    }

}
