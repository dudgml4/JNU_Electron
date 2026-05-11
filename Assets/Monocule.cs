using UnityEngine;

public class Monocule : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float scale;
    private Vector3 initPosition;

    [Header("Vibration Control")]
    public VibrationManager vibManager; // 매니저 연결

    private void Awake()
    {
        initPosition = transform.localPosition;
    }

    private void Update()
    {
        // 진동 모드이고 매니저가 허용했을 때만 위치 변경
        if (vibManager != null && vibManager.GetVibrationStatus())
        {
            Thrilling();
        }
        else
        {
            // OFF일 때는 정확히 원래 위치로 돌려놔야 MonoLine도 제자리를 찾는다
            if (transform.localPosition != initPosition)
            {
                transform.localPosition = initPosition;
            }
        }
    }

    private void Thrilling()
    {
        // MonoLine이 이 위치값을 참조함
        Vector3 position = initPosition;

        float xValue = Random.Range(-scale, scale);
        float yValue = Random.Range(-scale, scale);
        float zValue = Random.Range(-scale, scale);

        position.x += xValue;
        position.y += yValue;
        position.z += zValue;

        transform.localPosition = position;
    }
}