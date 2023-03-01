using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    float inputX;
    Rigidbody rb;
    [SerializeField] float speed = 20f;
    float limitX = 21f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        if (transform.position.x > limitX)
        {
            transform.position = new Vector3(limitX, transform.position.y, transform.position.z);
            return;
        }
        if (transform.position.x < -limitX)
        {
            transform.position = new Vector3(-limitX, transform.position.y, transform.position.z);
            return;
        }
        if (inputX != 0)
        {
            Vector3 moveTo = new Vector3(inputX, 0, 0);
            rb.MovePosition(transform.position + moveTo * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity= Vector3.zero;
        }
    }
}
