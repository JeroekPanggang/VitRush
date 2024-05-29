using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int Value = 1;
    [SerializeField] private int itemPowerID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemPowerID == 1)
            {
                collision.GetComponent<Health>().AddHealth(Value);
                Destroy(gameObject);
            }
            
        }


    }
}



