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
        CurrencyController.Instance.CostMoney(costMoney);
        foreach (var Btn in EventController.Instance.ChoiceButtons)
        {
            Btn.GetComponent<Text>().text = null;
            Btn.interactable = false;
        }
    }
}
