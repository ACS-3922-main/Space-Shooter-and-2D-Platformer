using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float _speed = 5;
    private float _boundary = 2.5f;
    Rigidbody2D _rb;
    private Vector3 respawnPoint;
    private bool check;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        respawnPoint = transform.position;
    }

    void Update(){
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
            vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            vel.x = -_speed;
        }
        else if (check && Input.GetKeyDown(KeyCode.Space)) {
            vel.y = _speed+2;
        }
        else {
            vel.x = 0;
        }
        _rb.velocity = vel;

        Vector3 pos = transform.position;
        if (pos.y > _boundary) {
            pos.y = _boundary;
        }
        transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Finish") {
            transform.position = respawnPoint;
        }
        else if(other.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
        if(other.gameObject.name == "EnemyHorizontal")
        {
            transform.position = respawnPoint;
        }
        else if(other.gameObject.name == "EnemyVertical")
        {
            transform.position = respawnPoint;
        }
        if(other.tag == "Win")
        {
            Debug.Log("Win");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") 
        {
            check = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") 
        {
            check = false;
        }
    }
}
