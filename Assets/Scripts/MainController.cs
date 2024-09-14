using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public static MainController Instance;
    public EventsConfig GameEventsList;
    public EventsConfig AllInitialEventsList;
    public GameObject ChooseEventPanel;
    public GameObject EventDialogPrefab;
    public Image[] PeriodIcons;
    public Text TipText;
    public Image FrontImage;
    public Image BackImage;
    public Sprite[] BGSprites;
    public bool isFadeFinish = false;
    public bool isEvent;
    public bool isJob;
    //public List<Event> InitialEventsList;
    //public List<Event> EmergencyEventsList;
    public List<int> amountChanged;
    public int date = 11;
    public Text DateText;
    public GameObject Shop;
    public ChoiceConfig ShopConfig;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        GameEventsList.EventsList.Clear();

        for (int i = 0; i < AllInitialEventsList.EventsList.Count; i++)
        {
            GameEventsList.EventsList.Add(AllInitialEventsList.EventsList[i]);
        }
        
        amountChanged.Clear();

        for (int i = 0; i < 6; i++)
        {
            amountChanged.Add(0);
        }
    }
    private void Start()
    {
        ChangePeriodIcon(EventController.Instance.Time);
        StartCoroutine(TimeChange(EventController.Instance.Time));
    }

    public void LoadEvent(int time)
    {
        ///检测天数 如果第11天就结算
        ///另设一个list 到时新游戏直接等于
        List<Event> EventsToBeLoad;
        EventsToBeLoad = GameEventsList.EventsList.FindAll(evt => evt.appearTime == time);
        int index = Random.Range(0, EventsToBeLoad.Count);
        if (!EventsToBeLoad[index].isEmergency)
        {
            PanelController.Instance.OpenEvent();
            var EventToBeChoose = EventsToBeLoad.FindAll(evt => !evt.isEmergency);

            for (int i = 0; i < 3; i++)
            {
                if (EventToBeChoose.Count == 0) 
                {
                    continue;
                }
                int randomIndex = Random.Range(0, EventToBeChoose.Count);
                var tempEvent = EventToBeChoose[randomIndex];
                EventToBeChoose.RemoveAt(randomIndex);
                var EventDialog = Instantiate(EventDialogPrefab, ChooseEventPanel.transform);
                EventDialog.GetComponent<JobHolder>().JobName.text = tempEvent.eventDescription;
                EventDialog.GetComponent<JobHolder>().jobEvent = tempEvent;
                //将事件信息输入进去 并且显示 请选择事件

            }
            TipText.text += "\nPick one TODO on your Phone";
        }
        else
        {
            EventController.Instance.StartCoroutine(EventController.Instance.ShowText(EventsToBeLoad[index]));
            TipText.text = null;
        }
    }

    public void ChangePeriodIcon(int time)
    {
        foreach(var image in PeriodIcons)
        {
            image.color = new Color(1, 1, 1, 0.25f);
        }
        if (time < 3)
        {
            PeriodIcons[time].color = new Color(1, 1, 1, 1);
        }
        else
        {
            PeriodIcons[2].color = new Color(1, 1, 1, 1);
        }
    }

    public IEnumerator FadeBG(int time)
    {
        BackImage.sprite = BGSprites[time];
        isFadeFinish = false;
        for (float i = 1; i > 0; i -= 0.1f) 
        {
            FrontImage.color = new Color(1, 1, 1, i);
            yield return new WaitForSeconds(0.1f);
        }
        isFadeFinish = true;
        FrontImage.sprite = BGSprites[time];
        FrontImage.color = new Color(1, 1, 1, 1);
    }

    public IEnumerator TimeChange(int time)
    {
        switch (time)
        {
            case 0:
                EventController.Instance.CleanAllText();
                TipText.text = "Another day, it's time for interview now.";
                isJob = true;
                isEvent = false;
                ChangePeriodIcon(time);
                PanelController.Instance.OpenToDo();
                StartCoroutine(FadeBG(time));
                yield break;
            case 1:
                EventController.Instance.CleanAllText();
                TipText.text = "It,s afternoon now!";
                isJob = false;
                isEvent = true;
                ChangePeriodIcon(time);
                PanelController.Instance.OpenEvent();
                StartCoroutine(FadeBG(time));
                break;
            case 2:
                EventController.Instance.CleanAllText();
                TipText.text = "It's evening now!";
                isJob = false;
                isEvent = true;
                ChangePeriodIcon(time);
                PanelController.Instance.OpenEvent();
                StartCoroutine(FadeBG(time));
                break;
            case 3:
                EventController.Instance.CleanAllText();
                TipText.text = "It's late night now, buy something and then have a rest!";
                isJob = false;
                isEvent = true;
                ChangePeriodIcon(time);
                StartCoroutine(FadeBG(2));
                //Shop and Day end
                ShowShop();
                yield break;
        }
        
        yield return new WaitUntil(() => isFadeFinish);
        //yield return new WaitForSeconds(0.5f);
        LoadEvent(time);
    }

    public void AmountChanged(List<int> list, int money)
    {
        for (int i = 0; i < list.Count; i++)
        {
            amountChanged[i] += list[i];
        }
        amountChanged[5] += money;

        for (int i = 0; i < 6; i++)
        {
            DateController.Instance.Days[date + 3].GetComponent<ChangeInformation>().changes[i] = amountChanged[i];
        }
    }

    public void DayEnd()
    {
        DateController.Instance.Days[date + 3].GetComponentsInChildren<Image>()[1].enabled = true;
        date++;
        DateText.text = "July " + date;
        //date ui update
        EventController.Instance.Time = 0;
        
        for (int i = 0; i < 5; i++)
        {
            amountChanged[i] = 0;
        }
        PersonaController.Instance.DailyChange();

        if (PersonaCheck())
        {
            StartCoroutine(TimeChange(EventController.Instance.Time));
        }
        else
        {
            if (date == 21) 
            {

            }
        }
    }

    public bool PersonaCheck()
    {
        if (PersonaController.Instance.personaAmountList.Exists(amount => amount <= 10 || amount >= 90)) 
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void ShowShop()
    {
        foreach (var Btn in EventController.Instance.ChoiceButtons)
        {
            Btn.GetComponentInChildren<Text>().text = null;
            Btn.interactable = true;
        }
        for (int i = 0; i < ShopConfig.choicesList.Count; i++) 
        {
            EventController.Instance.ChoiceButtons[i].GetComponentInChildren<Text>().text =ShopConfig.choicesList[i].description;
            EventController.Instance.ChoiceButtons[i].onClick.AddListener(ShopConfig.choicesList[i].RaiseEvent);
        }
    }
}
