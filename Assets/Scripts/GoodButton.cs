using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodButton : MonoBehaviour
{
    public bool isSoldOut;
    public string GoodName;
    public Text SoldOutText;
    [TextArea]
    public string description;
    public int costMoney;
    public Image ChosenGood;
    public Text GoodDescription;

    public void ChooseGood()
    {
        ChosenGood.sprite = this.GetComponent<Image>().sprite;
        GoodDescription.text = description;
    }

}
