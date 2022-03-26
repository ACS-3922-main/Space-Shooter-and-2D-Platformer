using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour{

    private float _speed = 4;
    AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
        GetComponent<AudioSource>().Play();
    }

    void Update()    {
        transform.Translate(0, _speed * Time.deltaTime, 0);
        if (transform.position.y > 6.0f)
            Destroy(gameObject);
    }
}
