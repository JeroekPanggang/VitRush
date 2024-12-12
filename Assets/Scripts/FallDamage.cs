using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public float teleportX;
    public float teleportY;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);

            Movement.Player.TeleportIdiotWhoFall(teleportX, teleportY);
        }
    }

}
