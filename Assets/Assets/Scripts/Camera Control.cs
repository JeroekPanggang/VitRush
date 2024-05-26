using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private float currentPosX;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance = 0.8f;
    [SerializeField] private float cameraSpeed = 1f;
    private float lookAhead;


//   [SerializeField] float BatasKiri = -2.0f;
//   [SerializeField] float BatasKanan = 45.86f;
    private void Update()
    {
 //       if (player.position.x > BatasKiri && player.position.x < BatasKanan)
 //       {
            transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
 //       }
        

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
