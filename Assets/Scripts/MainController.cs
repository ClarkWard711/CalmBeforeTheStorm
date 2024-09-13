using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public List<Event> EventsList;
    public GameObject ChooseEventPanel;
    public GameObject EventDialogPrefab;
    //public List<Event> InitialEventsList;
    //public List<Event> EmergencyEventsList;

    public void LoadEvent(int time)
    {
        ///另设一个list 到时新游戏直接等于
        List<Event> EventsToBeLoad;
        EventsToBeLoad = EventsList.FindAll(evt => evt.appearTime == time);
        int index = Random.Range(0, EventsToBeLoad.Count);
        if (!EventsToBeLoad[index].isEmergency)
        {
            var EventToBeChoose = EventsToBeLoad.FindAll(evt => !evt.isEmergency);

            for (int i = 0; i < 3; i++)
            {
                var EventDialog = Instantiate(EventDialogPrefab, ChooseEventPanel.transform);
                int randomIndex = Random.Range(0, EventToBeChoose.Count);
                //将事件信息输入进去 然后移除出list
            }
        }
    }
}
