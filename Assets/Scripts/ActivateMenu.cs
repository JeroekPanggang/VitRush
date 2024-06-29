using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject credit;
    public void ToggleHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            bool isActive = howToPlayPanel.activeSelf;
            howToPlayPanel.SetActive(!isActive);
        }
    }

    public void ToggleCredit()
    {
        if (credit != null)
        {
            bool isCredit = credit.activeSelf;
            credit.SetActive(!isCredit);
        }
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
    }

    public void CloseCredit()
    {
        if(credit != null)
        {
            credit.SetActive(false);
        }
    }

}
