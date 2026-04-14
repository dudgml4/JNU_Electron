using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomVibration : MonoBehaviour
{
    public float intensity = 0.5f; // 흔들림 강도 (필요시 Inspector에서 조절)
    public float speed = 10f;      // 흔들림 속도 (필요시 Inspector에서 조절)

    private Vector3 originalPosition;

    void Start()
    {
        // 게임이 시작될 때(Play 버튼을 누를 때) 원자의 초기 위치를 기억합니다.
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        // 버튼과 상관없이 매 프레임마다 무조건 흔들림을 계산해서 적용합니다.
        float x = (Mathf.PerlinNoise(Time.time * speed, 0) - 0.5f) * intensity;
        float y = (Mathf.PerlinNoise(0, Time.time * speed) - 0.5f) * intensity;
        float z = (Mathf.PerlinNoise(Time.time * speed, Time.time * speed) - 0.5f) * intensity;

        // 원래 위치를 기준으로 진동 좌표를 더해줍니다.
        transform.localPosition = originalPosition + new Vector3(x, y, z);
    }
}