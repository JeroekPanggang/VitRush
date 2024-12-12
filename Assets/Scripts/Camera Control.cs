using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private float currentPosX;
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance = 0.8f;
    [SerializeField] private float upDistance = 0.8f;
    [SerializeField] private float cameraSpeed = 1f;
    private float lookAhead;
    private float lookUp;

    

//   [SerializeField] float BatasKiri = -2.0f;
//   [SerializeField] float BatasKanan = 45.86f;
    private void Update()
    {
        
        
            transform.position = new Vector3(player.position.x + lookAhead, player.position.y + lookUp, transform.position.z);
            lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
            lookUp = Mathf.Lerp(lookUp, (upDistance * player.localScale.y), Time.deltaTime * cameraSpeed);
        

    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
