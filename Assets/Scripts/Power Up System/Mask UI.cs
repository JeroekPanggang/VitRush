using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaskUI : MonoBehaviour
{
    [SerializeField] private Health playerMaskUI;
    [SerializeField] private Image Mask;

    private void Start()
    {
        //HealthBarTotal.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
       // HealthBarCurrent.fillAmount = playerHealth.currentHealth / 10;

    }
}
