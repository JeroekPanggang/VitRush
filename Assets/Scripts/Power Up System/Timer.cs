using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class Timer : MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    [SerializeField] private Image uiFill;
    //[SerializeField] private Text uiText;
    [SerializeField] private GameObject test;

    public int Duration;
    public int remainingDuration  { get; private set; }

    //private int remainingDuration;

    private bool Pause;

    private void Start()
    {
        test.SetActive(false);
    }
    public void StartMask(int MaskDuration)
    {
       Duration = MaskDuration;
        test.SetActive(true);
        Being(MaskDuration);
    }

    private void Being(int Duration)
    {
        remainingDuration = Duration;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            if (!Pause)
            {
                Physics2D.IgnoreLayerCollision(13, 14, true);
                Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        test.SetActive(false);
        Physics2D.IgnoreLayerCollision(13, 14, false);
    }


 
}
