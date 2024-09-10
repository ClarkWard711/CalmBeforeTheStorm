using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Events",menuName ="Event_")]

public class Event : ScriptableObject
{
    [System.Serializable]
    public class TextAndDuration
    {
        public string text;
        public float duration = 0.1f;
    }
    public bool isInitialEvent;
    public bool isEmergency;
    public Sprite Icon;
    public string eventDescription;
    [SerializeField] public List<TextAndDuration> eventTextList;
    public List<TextAndDuration> EventTextList => eventTextList;
    public int appearTime;
    public int timeCost;
    public ChoiceConfig eventChoices;
    public TextAsset textFile;


    public void OnValidate()
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

