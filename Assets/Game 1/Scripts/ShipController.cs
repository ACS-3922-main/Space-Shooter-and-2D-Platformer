using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour{

    [SerializeField] GameObject _shot;

    private float _speed = 5;
    private float _boundary = 3.5f;
    Rigidbody2D _rb;
    AudioSource audio;
    public Animator transition;
    private float sec = 3.0f;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        Vector2 vel = _rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
            vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            vel.x = -_speed;
        }
        else {
            vel.x = 0;
        }
        _rb.velocity = vel;

        Vector3 pos = transform.position;
        if (pos.x > _boundary) {
            pos.x = _boundary;
        }
        else if (pos.x < -_boundary) {
            pos.x = -_boundary;
        }
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(_shot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "AShot") {
            GetComponent<AudioSource>().Play();
            transition.SetTrigger("Death");
            FindObjectOfType<UIScript>().Miss();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("enableBoxCollider",3);
            Destroy(other.gameObject);
        }
    }
    private void enableBoxCollider()
    {
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
