using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject infoPanel; // 인스펙터에서 InfoPanel을 연결할 칸

    // 정보창 열기
    public void OpenInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
    }

    // 정보창 닫기
    public void CloseInfo()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}