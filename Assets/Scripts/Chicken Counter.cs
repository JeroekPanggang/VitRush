using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChickenCounter : MonoBehaviour
{
    public static ChickenCounter Instance;

    public TMP_Text chickenText;
    public  int currentChicken = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        chickenText.text = currentChicken.ToString();    
    }

    public void IncreaseChicken(int Value)
    {
        currentChicken += Value;
        chickenText.text = currentChicken.ToString();
    }
}
