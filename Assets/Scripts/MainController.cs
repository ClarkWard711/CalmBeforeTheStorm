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
    //public List<Event> InitialEventsList;
    //public List<Event> EmergencyEventsList;

    private void Awake()
    {
        GameEventsList.EventsList.Clear();
        GameEventsList = AllInitialEventsList;
        if (Instance == null)
        {
            Instance = this;
        }
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

                //将事件信息输入进去 并且显示 请选择事件

            }
        }
        else
        {
            EventController.Instance.StartCoroutine(EventController.Instance.ShowText(EventsToBeLoad[index]));
        }
    }
}
