using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventController : MonoBehaviour
{
    public GameObject TexturePrefab;
    public GameObject TexturePanel;
    public GameObject ShowTextPanel;
    int index = 0;
    bool isTextFinished = false;
    bool isReturnPressed;
    public Event currentEvent;

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
            ShowAllText(currentEvent);
        }
    }

    IEnumerator ShowText(Event currentEvent)
    {
        isTextFinished = false;
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
        index = 0;
    }

    public void ShowAllText(Event currentEvent)
    {
        if (isTextFinished && index != currentEvent.eventTextList.Count) 
        {
            ShowText(currentEvent);
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
        string temp = "TestTextFunction";
        TexturePanel.GetComponent<Text>().text = null;
        for (int i = 0; i < temp.Length; i++)
        {
            TexturePanel.GetComponent<Text>().text += temp[i];
            yield return new WaitForSeconds(0.1f);
        }
        isTextFinished = true;
    }
}
