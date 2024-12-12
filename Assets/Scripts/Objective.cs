using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public int Value;
    [SerializeField] int ItemID;
    [SerializeField] private AudioSource itemPick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ItemID == 1)
            {
                Destroy(gameObject);
                //Debug.Log("Kena Ayam");
                GameManager.manager.IncreaseChicken(Value);
            }

            else if (ItemID == 2)
            {
                Destroy(gameObject);
                // Debug.Log("Kena Apel");
                GameManager.manager.IncreaseApple(Value);
            }

            else if (ItemID == 3)
            {
                Destroy(gameObject);
                //Debug.Log("Kena Oatmeal");
                GameManager.manager.IncreaseOatmeal(Value);
            }

            else if (ItemID == 4)
            {
                Destroy(gameObject);
                //Debug.Log("Kena Orange");
                GameManager.manager.IncreaseOrange(Value);
            }
            itemPick.Play();
        }
        
        
    }


}
