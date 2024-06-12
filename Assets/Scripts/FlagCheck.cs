using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlagCheck : MonoBehaviour
{
    public int AppleObjective;
    public int ChickenObjective;
    public int OatmealObjective;
    public int OrangeObjective;

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
           // Debug.Log("Kena Bendera");
        }

    }

    // apple oatmeal orange chicken
    public void GetObjective(int A, int Ot, int Or, int C)
    {

        AppleObjective = A;
        ChickenObjective = C;
        OatmealObjective = Ot;
        OrangeObjective = Or;

        Debug.Log(AppleObjective);
    }

}