using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyController : MonoBehaviour
{
    public static CurrencyController Instance;
    public Text MoneyNum;
    public int Money;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        CostMoney(-1000);
    }
    private void Update()
    {
        MoneyNum.text = Money.ToString();
    }
    public void CostMoney(int amount)
    {
        if (amount == 0) return;
        Money -= amount;
        //考虑做不做飘字
    }
}
