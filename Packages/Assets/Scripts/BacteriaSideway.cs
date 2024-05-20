using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSideway : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    [Header("Enemy Move Point")]
    [SerializeField] private float firstPoint;
    [SerializeField] private float lastPoint;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {

    }

    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x > firstPoint)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < lastPoint)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
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
