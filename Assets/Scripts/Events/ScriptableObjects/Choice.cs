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
            //method
            return;
        }
        EventController.Instance.StartCoroutine(EventController.Instance.ShowText(eventCallUp));
        EventController.Instance.ClearChoiceButtons();
        //CurrencyController.Instance.CostMoney(costMoney);
        EventController.Instance.isAllShown = false;
    }
}
