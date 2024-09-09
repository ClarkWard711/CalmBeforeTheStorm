using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Choice_", menuName = "Choice/Choice")]

public class Choice : ScriptableObject
{
    public string description;
    public List<int> affectCountList;
    public Event eventCallUp;
    public int costMoney;
}
