using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [Header("ID Item")]
    [SerializeField] private int itemPowerID;

    [Header("Healing Power per Hearth Value")]
    private int Value = 1;
    [Header("Mask Duration per Second")]
    [SerializeField] public int MaskDuration;

    [SerializeField] private AudioSource itemPick;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (itemPowerID == 1)
            {
                collision.GetComponent<Health>().AddHealth(Value);
                Destroy(gameObject);
                
            }
            
            else if (itemPowerID == 2)
            {
                collision.GetComponent<Timer>().StartMask(MaskDuration);
                Destroy(gameObject);
                
            }

            itemPick.Play();
        }


    }
}



