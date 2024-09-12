using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;  // ������Ҫ��ʾ/���ص� Panel UI

    void Start()
    {
        // ��ʼʱ�������
        panel.SetActive(false);
    }

    // �������������������ťʱ���������������ʾ���
    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    // �����������ķ���
    public void HidePanel()
    {
        panel.SetActive(false);
    }
}




