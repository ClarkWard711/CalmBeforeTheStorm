using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobInit : MonoBehaviour
{
    public List<bool> finishList;
    public List<string> JobNameList;
    public GameObject Content;
    public GameObject jobPrefab;
    public List<Sprite> JobAvatarList;
    public EventsConfig AllJobEvent;
    public List<Event> JobEventsList;
    private void Awake()
    {
        finishList.Clear();
        for (int i = 0; i < 10; i++)
        {
            finishList.Add(false);
            Instantiate(jobPrefab, Content.transform);
        }
        JobEventsList.Clear();
        JobEventsList = AllJobEvent.EventsList;

        JobNameList.Clear();
        JobNameList.Add("Programmer");
        JobNameList.Add("Accountant");
        JobNameList.Add("Hotel Waiter");
        JobNameList.Add("Customer Service");
        JobNameList.Add("Insurance Salesman");
        JobNameList.Add("Teacher");
        JobNameList.Add("Human Resource");
        JobNameList.Add("Project Leader");
        JobNameList.Add("Product Planner");
        JobNameList.Add("Head Chef");

        for (int i = 0; i < 10; i++)
        {
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().JobName.text = JobNameList[i];
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().JobAvatar.sprite = JobAvatarList[i];
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().JobOREvent = true;
            Content.transform.GetChild(i).gameObject.GetComponent<JobHolder>().jobEvent = JobEventsList[i];
        }
        
    }
}
