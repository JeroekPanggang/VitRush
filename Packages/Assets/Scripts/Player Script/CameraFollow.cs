using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Camera;
    private CameraControl cameraControl;
    private void Start()
    {
        cameraControl = Camera.GetComponent<CameraControl>();
    }

    private void OnCollisionEnter2D(Collision2D stopCam)
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraLimit"))
        {
            cameraControl.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CameraLimit"))
        {
            cameraControl.enabled = true;
        }
    }

}
