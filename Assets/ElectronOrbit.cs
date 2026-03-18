using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronOrbit : MonoBehaviour
{
    // 유니티 에디터에서 원자핵(Nucleus)을 여기에 드래그해서 넣기
    public Transform nucleus;

    // 회전 속도 (숫자가 클수록 빠름)
    public float speed = 50f;

    // 랜덤 회전축을 저장할 변수 (C# 내부용)
    Vector3 randomAxis;

    // 게임 시작 시 한 번 실행
    void Start()
    {
        // 회전축을 랜덤으로 정하기
        // InsideUnitSphere는 반지름 1인 구 안의 랜덤한 좌표(x, y, z)를 반환
        randomAxis = Random.insideUnitSphere.normalized;
    }

    void Update()
    {
        if (nucleus != null)
        {
            // 랜덤으로 정해진 randomAxis를 사용
            // RotateAround(중심점, 회전축, 각도)
            transform.RotateAround(nucleus.position, randomAxis, speed * Time.deltaTime);
        }
    }
}