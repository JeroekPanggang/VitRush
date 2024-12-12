using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaUpDown : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    [Header("Enemy Move Point")]
    [SerializeField] private float firstPoint;
    [SerializeField] private float lastPoint;
    private bool movingDown;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {

    }

    private void Update()
    {
        if (movingDown)
        {
            if (transform.position.y > firstPoint)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed *Time.deltaTime, transform.position.z);
            }
            else
                movingDown = false;
        }
        else
        {
            if (transform.position.y < lastPoint)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                movingDown = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
