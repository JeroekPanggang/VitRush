using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveCounter : MonoBehaviour
{
    public static ObjectiveCounter Instance;

    // Chicken
    public TMP_Text chickenText;
    private int currentChicken = 0;

    // Apple
    public TMP_Text appleText;
    private int currentApple = 0;

    // Oatmeal
    public TMP_Text oatmealText;
    private int currentOatmeal = 0;

    // Orange
    [SerializeField] TMP_Text orangeText;
    private int currentOrange = 0;


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        chickenText.text = currentChicken.ToString();  
        appleText.text = currentApple.ToString();
        oatmealText.text = currentOatmeal.ToString();
        orangeText.text = currentOrange.ToString();
    }

    public void IncreaseChicken(int Value)
    {
        currentChicken += Value;
        chickenText.text = currentChicken.ToString();
    }

    public void IncreaseApple(int Value)
    {
        currentApple += Value;
        appleText.text = currentApple.ToString();
    }

    public void IncreaseOatmeal(int Value)
    {
        currentOatmeal += Value;
        oatmealText.text = currentOatmeal.ToString();
    }

    public void IncreaseOrange(int Value)
    {
        currentOrange += Value;
        orangeText.text = currentOrange.ToString();
    }


    public void ObjectiveCheck(int A, int B, int C, int D)
    {
        if (A >= currentApple && B >= currentChicken && C >= currentOatmeal 
            && D >= currentOrange )
        {
            Debug.Log("Stage Finished");
        } else
        {
            Debug.Log("Objective not Fulfilled");
        }
    }
}
