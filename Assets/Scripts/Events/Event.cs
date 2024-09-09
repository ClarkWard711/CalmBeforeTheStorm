using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Events",menuName ="Event_")]

public class Event : ScriptableObject
{
    public string eventDescription;
    public int appearTime;
    public int timeCost;
    public List<Choice> eventChoicesList;
}
