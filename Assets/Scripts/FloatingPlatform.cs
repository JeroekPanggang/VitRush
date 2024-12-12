using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FloatingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Move Point")]
    [SerializeField] private float LowPoint;
    [SerializeField] private float UpPoint;

    private bool movingUP;
    private float leftEdge;
    private float rightEdge;

 
    private void Awake() 
    { 

    }

    private void Update()
    {
        if (movingUP == true)
        {
            if (transform.position.y < UpPoint) // Sedang bergerak naik
            {
                transform.position = new Vector3(transform.position.x, (transform.position.y + speed * Time.deltaTime), transform.position.z);
            }
            else
                movingUP = false; // Tidak bergerak naik
        }
        else // Sedang bergerak turun
        {
            if (transform.position.y  > LowPoint) // Sedang bergerak turun
            {
                transform.position = new Vector3(transform.position.x, (transform.position.y - speed * Time.deltaTime), transform.position.z);
            }
            else
                movingUP = true; // Tidak bergerak turun
        }

    }

 

}
