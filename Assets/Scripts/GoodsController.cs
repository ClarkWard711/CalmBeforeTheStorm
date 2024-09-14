using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsController : MonoBehaviour
{
    public GameObject[] Goods;

    public Button buyButton;

    public void effect(int i)
    {
        Goods[i].GetComponent<GoodButton>().isSoldOut = true;
        Goods[i].GetComponent<GoodButton>().SoldOutText.color = new Color(1, 1, 1, 0);
        Goods[i].GetComponent<GoodButton>().GetComponent<Button>().interactable = false;
    }
}
