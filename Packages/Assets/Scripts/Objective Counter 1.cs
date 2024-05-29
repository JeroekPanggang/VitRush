using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveCounter1 : MonoBehaviour
{
    public static ObjectiveCounter1 Instance;

    // Chicken
    [Header("Current")]
    [SerializeField] public TMP_Text chickenText;
    [SerializeField] public TMP_Text appleText;
    [SerializeField] public TMP_Text oatmealText;
    [SerializeField] public TMP_Text orangeText;

    private int currentChicken, currentApple, currentOatmeal,  currentOrange = 0;
    [SerializeField] private GameObject NotEnough;

    [Header("Target")]
    [SerializeField] public TMP_Text chickenNeedText;
    [SerializeField] public TMP_Text appleNeedText;
    [SerializeField] public TMP_Text oatmealNeedText;
    [SerializeField] public TMP_Text orangeNeedText;

    [Header("Activate UI")]
    [SerializeField] private GameObject Apple;
    [SerializeField] private GameObject Orange;
    [SerializeField] private GameObject Chicken; 
    [SerializeField] private GameObject Oatmeal;


    private int Level;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        chickenText.text = currentChicken.ToString();  
        appleText.text = currentApple.ToString();
        oatmealText.text = currentOatmeal.ToString();
        orangeText.text = currentOrange.ToString();

        GameManager.gm.StartingLevel1();
        RefreshObjective();
        Level = 1;
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


    public void DisplayTarget(int napple, int noat, int nor, int nchi)
    {
        chickenNeedText.text = "/ " + nchi.ToString();
        appleNeedText.text = "/ " + napple.ToString(); 
        oatmealNeedText.text = "/ " + noat.ToString();
        orangeNeedText.text = "/ " + nor.ToString();
    }

    // Cek Buah di FLag
    public void ObjectiveCheck(int A, int B, int C, int D)
    {
        if (currentApple >= A && currentChicken >= B && currentOatmeal >= C 
            && currentOrange >= D)
        {
            

            if (Level == 1)
            {
                Debug.Log("Stage 1 Finished");
                GameManager.gm.StartingLevel2();
                PlayerGerak.Player.transform.position = new Vector3(120, 3, 1);
                Level += 1;
            } if (Level == 2)
            {
                Debug.Log("Stage 2 Finished");

            }
        } else
        {
            NotEnough.SetActive(true);

            Invoke("TurnOffNotEnoughScreen", 5f);
        }
    }


    public void TurnOffNotEnoughScreen()
    {
        NotEnough.SetActive(false);
    }

    public void RefreshObjective()
    {
        currentApple = currentChicken = currentOatmeal = currentOrange = 0;

    }

    public void ActivateUI(bool i, bool j, bool k, bool l)
    {

        // Apple Orange Chicken Oatmeal
        Apple.SetActive(i);
        Oatmeal.SetActive(l);
        Orange.SetActive(j);
        Chicken.SetActive(k);
    }
}
