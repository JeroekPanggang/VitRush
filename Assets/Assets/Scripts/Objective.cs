using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public int Value;
    [SerializeField] int ItemID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ItemID == 1)
            {
                Destroy(gameObject);
                Debug.Log("Kena Ayam");
                ObjectiveCounter.Instance.IncreaseChicken(Value);
            }

            else if (ItemID == 2)
            {
                Destroy(gameObject);
                Debug.Log("Kena Apel");
                ObjectiveCounter.Instance.IncreaseApple(Value);
            }

            else if (ItemID == 3)
            {
                Destroy(gameObject);
                Debug.Log("Kena Oatmeal");
                ObjectiveCounter.Instance.IncreaseOatmeal(Value);
            }

            else if (ItemID == 4)
            {
                Destroy(gameObject);
                Debug.Log("Kena Orange");
                ObjectiveCounter.Instance.IncreaseOrange(Value);
            }
        }
        
        
    }


}
