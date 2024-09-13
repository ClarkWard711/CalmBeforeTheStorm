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
    int index = -1;
    bool isTextFinished = false;
    bool isReturnPressed;
    public bool isAllShown = false;
    public Event CurrentEvent;
    public float duration = 0.1f;

    private int Time = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        ChoiceButtons = ChoicePanel.GetComponentsInChildren<Button>();
        index = 0;
        StartCoroutine(ShowText(CurrentEvent));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
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
        TexturePanel.GetComponent<Text>().text = null;
        duration = 0.1f;
        for (int i = 0; i < currentEvent.eventTextList[index].text.Length; i++) 
        {
            TexturePanel.GetComponent<Text>().text += currentEvent.eventTextList[index].text[i];
            yield return new WaitForSeconds(duration);
        }
        isTextFinished = true;
        index++;
        
        if (index == currentEvent.eventTextList.Count) 
        {
            isAllShown = true;
            ShowChoices(currentEvent.eventChoices);
        }

    }

    public void ShowChoices(ChoiceConfig choiceConfig)
    {
        //增加金钱判断
        if (choiceConfig == null)
        {
            EventCheck();
            return;
        }
        index = 0;
        foreach(var Btn in ChoiceButtons)
        {
            Btn.GetComponentInChildren<Text>().text = null;
            Btn.interactable = true;
        }
        for (int i = 0; i < CurrentEvent.eventChoices.choicesList.Count; i++) 
        {
            ChoiceButtons[i].GetComponentInChildren<Text>().text = CurrentEvent.eventChoices.choicesList[i].description;
            ChoiceButtons[i].onClick.AddListener(CurrentEvent.eventChoices.choicesList[i].RaiseEvent);
        }
    }

    public void ClearChoiceButtons()
    {
        foreach (var Btn in ChoiceButtons)
        {
            Btn.onClick.RemoveAllListeners();
            Btn.GetComponentInChildren<Text>().text = "-";
        }
    }

    public void ShowAllText(Event currentEvent)
    {
        isReturnPressed = false;

        if (!isTextFinished) 
        {
            duration = 0f;
        }
        else if (!isAllShown) 
        {
            StartCoroutine(ShowText(currentEvent));
        }


        /*if (isTextFinished && !isAllShown)
        {
            StartCoroutine(ShowText(currentEvent));
        }
        else if (isTextFinished && isAllShown)
        {
            return;
        }
        else if (!isTextFinished) 
        {
            StopAllCoroutines();
            if (TexturePanel != null)
            {
                TexturePanel.GetComponent<Text>().text = null;
                TexturePanel.GetComponent<Text>().text = currentEvent.eventTextList[index].text;
            }

            isTextFinished = true;
            index++;

            if (index == currentEvent.eventTextList.Count)
            {
                ShowChoices(currentEvent.eventChoices);
            }
        }*/
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
