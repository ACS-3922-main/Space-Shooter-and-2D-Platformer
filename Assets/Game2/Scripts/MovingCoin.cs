using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCoin : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private GameObject platform;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = gameObject.transform.position.y - movementDistance+4;
        rightEdge = gameObject.transform.position.y + movementDistance;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (gameObject.transform.position.y > leftEdge)
            {
                gameObject.transform.position = new Vector3(transform.position.x , transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (gameObject.transform.position.y < rightEdge)
            {
                gameObject.transform.position = new Vector3(transform.position.x , transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            platform.SetActive(false);
        }
    }
}
