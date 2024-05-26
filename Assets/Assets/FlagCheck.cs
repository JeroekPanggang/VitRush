using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FlagCheck : MonoBehaviour
{
    [SerializeField] int AppleObjective;
    [SerializeField] int ChickenlObjective;
    [SerializeField] int OatmealObjective;
    [SerializeField] int OrangeObjective;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectiveCounter.Instance.ObjectiveCheck(AppleObjective, ChickenlObjective, OatmealObjective, OrangeObjective);
        }


    }
}