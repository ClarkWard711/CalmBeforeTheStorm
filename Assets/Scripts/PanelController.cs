using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject toDoPanel;
    public GameObject eventPanel;
    public GameObject callenderPanel;

    public void OpenToDo()
    {
        toDoPanel.SetActive(true);
        eventPanel.SetActive(false);
        callenderPanel.SetActive(false);
    }

    public void OpenEvent()
    {
        toDoPanel.SetActive(false);
        eventPanel.SetActive(true);
        callenderPanel.SetActive(false);
    }

    public void OpenCallender()
    {
        toDoPanel.SetActive(false);
        eventPanel.SetActive(false);
        callenderPanel.SetActive(true);
    }
}




