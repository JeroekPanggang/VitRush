using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;

    public void ToggleHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            bool isActive = howToPlayPanel.activeSelf;
            howToPlayPanel.SetActive(!isActive);
        }
    }

    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
    }

}
