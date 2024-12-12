using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Timer maskTimer;
    //[SerializeField] private PowerUp Duration;
    [SerializeField] private Image maskImage;



    // Update is called once per frame
    private void Update()
    {
        maskImage.fillAmount = Mathf.InverseLerp(0, maskTimer.Duration, maskTimer.remainingDuration);
        //Debug.Log("Mask Duration " + maskTimer.remainingDuration);
    }
}
