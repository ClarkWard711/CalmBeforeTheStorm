using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public static EventController Instance;


    public GameObject TexturePrefab;
    public GameObject TexturePanel;
    public GameObject ShowTextPanel;
    public TextAsset test;
    public GameObject ChoicePanel;
    public Button[] ChoiceButtons;
    int testIndex = 0;
    int index = 0;
    bool isTextFinished = false;
    bool isReturnPressed;
    public Event CurrentEvent;
    public List<Event> EventsList;

    private int Time = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ChoiceButtons = ChoicePanel.GetComponentsInChildren<Button>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            isReturnPressed = true;
        }
    }

    private void FixedUpdate()
    {
        if (isReturnPressed)
        {
            ShowAllText(CurrentEvent);
        }
    }

    public IEnumerator ShowText(Event currentEvent)
    {
        isTextFinished = false;
        CurrentEvent = currentEvent;
        Time += currentEvent.timeCost;
        TexturePanel = Instantiate(TexturePrefab, ShowTextPanel.transform);
        for (int i = 0; i < currentEvent.eventTextList[index].text.Length; i++) 
        {
            TexturePanel.GetComponent<Text>().text += currentEvent.eventTextList[index].text[i];
            yield return new WaitForSeconds(currentEvent.eventTextList[index].duration);
        }
        isTextFinished = true;
        index++;
        
        if (index == currentEvent.eventTextList.Count) 
        {
            ShowChoices(currentEvent.eventChoices);
        }

    }

    public void ShowChoices(ChoiceConfig choiceConfig)
    {
        if (choiceConfig == null)
        {
            EventCheck();
            return;
        }
        index = 0;
        foreach(var Btn in ChoiceButtons)
        {
            Btn.GetComponent<Text>().text = null;
            Btn.interactable = true;
        }
        for (int i = 0; i < CurrentEvent.eventChoices.choicesList.Count; i++) 
        {
            ChoiceButtons[i].GetComponent<Text>().text = CurrentEvent.eventChoices.choicesList[i].description;
            ChoiceButtons[i].onClick.AddListener(CurrentEvent.eventChoices.choicesList[i].RaiseEvent);
        }
    }

    public void ShowAllText(Event currentEvent)
    {
        isReturnPressed = false;
        if (isTextFinished && index != currentEvent.eventTextList.Count) 
        {
            StartCoroutine(ShowText(currentEvent));
        }
        else if (isTextFinished && index == currentEvent.eventTextList.Count)
        {
            return;
        }
        else
        {
            StopAllCoroutines();

            TexturePanel.GetComponent<Text>().text = null;
            TexturePanel.GetComponent<Text>().text = currentEvent.eventTextList[index].text;

            isTextFinished = true;
            index++;

            if (index == currentEvent.eventTextList.Count)
            {
                ShowChoices(currentEvent.eventChoices);
            }
        }
    }

    public void EventCheck()
    {
        switch (Time)
        {
            case 0:
                //另一个脚本写选择事件等方法
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
        }
    }

    [ContextMenu("Test")]
    public void Test()
    {
        isTextFinished = true;
        if (isTextFinished)
        {
            StartCoroutine(TestShowText());
        }
    }
    IEnumerator TestShowText()
    {
        isTextFinished = false;
        TexturePanel = Instantiate(TexturePrefab, ShowTextPanel.transform);
        var textInLines = test.text.Split('\n');
        string temp = textInLines[testIndex];
        TexturePanel.GetComponent<Text>().text = null;
        for (int i = 0; i < temp.Length; i++)
        {
            TexturePanel.GetComponent<Text>().text += temp[i];
            yield return new WaitForSeconds(0.1f);
        }
        isTextFinished = true;
        testIndex++;
    }
}
