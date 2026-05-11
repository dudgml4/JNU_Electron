using UnityEngine;
using UnityEngine.UI;
using TMPro; // 텍스트를 바꾸기 위해 필요합니다

public class VibrationManager : MonoBehaviour
{
    private bool isVibrationOn = false; // 기본값은 꺼짐
    public TextMeshProUGUI buttonText; // 버튼의 텍스트를 연결할 변수

    // 버튼을 눌렀을 때 실행될 함수
    public void ToggleVibration()
    {
        isVibrationOn = !isVibrationOn; // 현재 상태를 반전 (On <-> Off)

        if (isVibrationOn)
        {
            // 진동 켜짐 상태일 때
            buttonText.text = "진동 ON";
            Debug.Log("진동 기능이 활성화되었습니다.");

            // 모바일 실제 진동 테스트 (0.5초)
#if UNITY_ANDROID || UNITY_IOS
            Handheld.Vibrate();
#endif
        }
        else
        {
            // 진동 꺼짐 상태일 때
            buttonText.text = "진동 OFF";
            Debug.Log("진동 기능이 비활성화되었습니다.");
        }
    }

    // 다른 스크립트(분자 진동 로직 등)에서 현재 진동 여부를 확인할 때 사용
    public bool GetVibrationStatus()
    {
        return isVibrationOn;
    }
}