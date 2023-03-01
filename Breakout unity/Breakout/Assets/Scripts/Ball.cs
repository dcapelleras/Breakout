using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float startingSpeed = 10f;
    Vector3 startingPosition;
    Vector3 lastVelocity;
    Rigidbody rb;


    private void Awake()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        int randomSide = Random.Range(0, 2);
        Vector3 randomDir = new Vector3(randomSide, 1, 0);
        if (randomSide == 0)
        {
            randomDir.x = -1;
        }
        rb.velocity = randomDir * startingSpeed;
    }

    private void FixedUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {

        rb.velocity = Vector3.Reflect(lastVelocity, collision.contacts[0].normal);
        if (collision.collider.CompareTag("DownWall"))
        {
            GameManager.instance.ShowGameOver();
            transform.position = startingPosition;
            Time.timeScale = 0;
        }
    }
}
