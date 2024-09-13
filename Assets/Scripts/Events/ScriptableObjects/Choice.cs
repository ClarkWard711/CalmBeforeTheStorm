using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Choice_", menuName = "Choice/Choice")]

public class Choice : ScriptableObject
{
    [TextArea]
    public string description;
    public List<int> affectCountList;
    public Event eventCallUp;
    public int costMoney;

    public void RaiseEvent()
    {
        if (eventCallUp == null)
        {
            EventController.Instance.ClearChoiceButtons();
            EventController.Instance.EventCheck();
            return;
        }
        EventController.Instance.StartCoroutine(EventController.Instance.ShowText(eventCallUp));
        EventController.Instance.ClearChoiceButtons();

        for (int i = 0; i < affectCountList.Count; i++)
        {
            PersonaController.Instance.personaAmountList[i] += affectCountList[i];
        }
        PersonaController.Instance.ChangeAmount();
        CurrencyController.Instance.CostMoney(costMoney);
        MainController.Instance.AmountChanged(affectCountList, costMoney);
        EventController.Instance.isAllShown = false;
    }
}
