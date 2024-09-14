using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JobHolder : MonoBehaviour
{
    public Event jobEvent;
    public Text JobName;
    public Image JobAvatar;
    public Button AcceptButton;
    public bool JobOREvent;


    public void LoadEvent()
    {
        if (MainController.Instance.isJob)
        {
            if (!JobOREvent) 
            {
                EventController.Instance.WrongTip.text = "Please pick a job.";
            }
            else
            {
                EventController.Instance.CurrentEvent = jobEvent;
                EventController.Instance.StartCoroutine(EventController.Instance.ShowText(EventController.Instance.CurrentEvent));
                MainController.Instance.TipText.text = null;
                EventController.Instance.WrongTip.text = null;
                MainController.Instance.isEvent = false;
                MainController.Instance.isJob = false;
                Destroy(this.gameObject);
            }
        }

        if (MainController.Instance.isEvent)
        {
            if (JobOREvent)
            {
                EventController.Instance.WrongTip.text = "Please pick a Todo.";
            }
            else
            {
                EventController.Instance.CurrentEvent = jobEvent;
                MainController.Instance.GameEventsList.EventsList.Remove(jobEvent);
                EventController.Instance.StartCoroutine(EventController.Instance.ShowText(EventController.Instance.CurrentEvent));
                MainController.Instance.TipText.text = null;
                EventController.Instance.WrongTip.text = null;
                MainController.Instance.isEvent = false;
                MainController.Instance.isJob = false;
                if (MainController.Instance.ChooseEventPanel.transform.childCount > 0) 
                {
                    for (int i = 0; i < MainController.Instance.ChooseEventPanel.transform.childCount; i++)
                    {
                        Destroy(MainController.Instance.ChooseEventPanel.transform.GetChild(i).gameObject);
                    }
                }
            }
        }
    }
}
