using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameObject TexturePrefab;
    public GameObject TexturePanel;
    public GameObject ShowTextPanel;

    IEnumerator ShowText(Event currentEvent)
    {
        yield return null;
        for (int i = 0; i < currentEvent.eventTextList.Count; i++)
        {
            TexturePanel = Instantiate(TexturePrefab, ShowTextPanel.transform);
            yield return new WaitForSeconds(currentEvent.eventTextList[i].duration);
        }
    }
}
