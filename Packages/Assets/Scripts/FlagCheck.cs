using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class FlagCheck : MonoBehaviour
{
    private int AppleObjective;
    private int ChickenObjective;
    private int OatmealObjective;
    private int OrangeObjective;

    public static FlagCheck flags;

    private void Awake()
    {
        flags = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ObjectiveCounter1.Instance.ObjectiveCheck(AppleObjective, ChickenObjective, OatmealObjective, OrangeObjective);
        }

    }

    // apple oatmeal orange chicken
    public void GetObjective(int A, int Ot, int Or, int C)
    {
        AppleObjective = A;
        ChickenObjective = C;
        OatmealObjective = Ot;
        OrangeObjective = Or;
    }

}