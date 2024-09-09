using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Events",menuName ="Event_")]

public class Event : ScriptableObject
{
    public bool isInitialEvent;
    public Sprite Icon;
    public string eventDescription;
    public List<TextAndDuration> eventTextList;
    public int appearTime;
    public int timeCost;
    public ChoiceConfig eventChoice;
    public TextAsset textFile;

    public class TextAndDuration
    {
        public string text;
        public float duration = 0.1f;
    }

    public void OnEnable()
    {
        if (!textFile) return;
        eventTextList.Clear();
        var textInLines = textFile.text.Split('\n');
        foreach (var line in textInLines)
        {
            TextAndDuration temp = new()
            {
                text = line
            };
            eventTextList.Add(temp);
        }
    }
}

