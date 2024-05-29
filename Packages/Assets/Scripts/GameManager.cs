using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject LVL1, LVL2, MAP1, MAP2;
    public static GameManager gm;
    private void Awake()
    {
        gm = this;
    }

    // apple oatmeal orange chicken
    public void StartingLevel1()
    {
        LVL1.SetActive(true);
        MAP1.SetActive(true);

        MAP2.SetActive(false);
        LVL2.SetActive(false);

        ObjectiveCounter1.Instance.DisplayTarget(2, 0, 1, 0);
        ObjectiveCounter1.Instance.ActivateUI(true, true, false, false);
        FlagCheck.flags.GetObjective(2, 0, 1, 0);

    }

    public void StartingLevel2()
    {
        ObjectiveCounter1.Instance.RefreshObjective();
        LVL2.SetActive(true);
        MAP2.SetActive(true);

        LVL1.SetActive(false);
        MAP1.SetActive(false);

        ObjectiveCounter1.Instance.DisplayTarget(1, 2, 1, 3);
        ObjectiveCounter1.Instance.ActivateUI(true, true, true, true);
        FlagCheck.flags.GetObjective(1, 2, 1, 3);
        PlayerGerak.Player.UnlockDash();

    }

}
