using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Current")]
    [SerializeField] public TMP_Text chickenText;
    [SerializeField] public TMP_Text appleText;
    [SerializeField] public TMP_Text oatmealText;
    [SerializeField] public TMP_Text orangeText;

    private int currentChicken, currentApple, currentOatmeal, currentOrange = 0;
    [SerializeField] private GameObject NotEnough;

    [Header("WIN UI")] // Lose UI ada di Player Health
    [SerializeField] private GameObject winUI;

    [Header("Target Objective")]
    [SerializeField] private int targetChicken;
    [SerializeField] private int targetApple;
    [SerializeField] private int targetOatmeal;
    [SerializeField] private int targetOrange;

    [Header("Target Objective Text")]
    [SerializeField] public TMP_Text TargetchickenText;
    [SerializeField] public TMP_Text TargetappleText;
    [SerializeField] public TMP_Text TargetoatmealText;
    [SerializeField] public TMP_Text TargetorangeText;

    [Header("Pindah Scene setelah Menang")]
    [SerializeField] private string NamaScene;

    public static GameManager manager;
    void Awake()
    {
        manager = this;
    }
    private void Start()
    {
        winUI.SetActive(false);
    }

    public void IncreaseChicken(int Value)
    {
        currentChicken += Value;
        if (currentChicken == targetChicken) { }
        {
            chickenText.GetComponent<TMP_Text>().color = Color.green;
            TargetchickenText.GetComponent<TMP_Text>().color = Color.green;

        }
        chickenText.text = currentChicken.ToString();
    }

    public void IncreaseApple(int Value)
    {
        currentApple += Value;
        if (currentApple == targetApple)
        {
            appleText.GetComponent<TMP_Text>().color = Color.green;
            TargetappleText.GetComponent<TMP_Text>().color = Color.green;

        }
        appleText.text = currentApple.ToString();
    }

    public void IncreaseOatmeal(int Value)
    {
        currentOatmeal += Value;
        if (currentOatmeal == targetOatmeal)
        {
            oatmealText.GetComponent<TMP_Text>().color = Color.green;
            TargetoatmealText.GetComponent<TMP_Text>().color = Color.green;

        }
        oatmealText.text = currentOatmeal.ToString();
    }

    public void IncreaseOrange(int Value)
    {
        currentOrange += Value;
        if(currentOrange == targetOrange) 
        {
            orangeText.GetComponent<TMP_Text>().color = Color.green;
            TargetorangeText.GetComponent<TMP_Text>().color= Color.green;
        
        }
        orangeText.text = currentOrange.ToString();
    }

    public void ObjectiveCheck()
    {
        if (currentChicken >= targetChicken && currentApple >= targetApple && currentOatmeal == targetOatmeal && currentOrange == targetOrange)
        {
            Debug.Log("Menang");
            winUI.SetActive(true);
            Movement.Player.NoMovement();
            Invoke("Menang", 4f);

        }
        else
        {
            NotEnough.SetActive(true);
            Invoke("TurnOffNotEnoughScreen", 3f);
        }
    }
    public void TurnOffNotEnoughScreen()
    {
        NotEnough.SetActive(false);
    }
    public void Menang()
    {
        SceneManagement.changeScene.ChangeScene(NamaScene);
    }
}
