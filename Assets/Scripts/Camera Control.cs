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

    private void Update()
    {

        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
