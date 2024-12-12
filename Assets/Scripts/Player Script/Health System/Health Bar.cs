using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private Image HealthBarTotal;
    [SerializeField] private Image HealthBarCurrent;

    private void Start()
    {
        HealthBarTotal.fillAmount = playerHealth.currentHealth / 10;
    }
    private void Update()
    {
        HealthBarCurrent.fillAmount = playerHealth.currentHealth / 10;

    }
}
