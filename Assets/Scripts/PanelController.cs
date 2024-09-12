using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;  // 拖入你要显示/隐藏的 Panel UI

    void Start()
    {
        // 开始时隐藏面板
        panel.SetActive(false);
    }

    // 可以在鼠标悬浮或点击按钮时调用这个方法来显示面板
    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    // 用来隐藏面板的方法
    public void HidePanel()
    {
        panel.SetActive(false);
    }
}




