using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RatioHalfBondFollower : MonoBehaviour
{
    [Header("연결 설정")]
    public Transform myAtom;      // 이 실린더가 시작될 원자 (본인 색상 쪽)
    public Transform targetAtom;  // 반대편 원자

    [Header("모양 설정")]
    public float bondThickness = 0.2f;
    [Range(0f, 1f)]
    public float myRatio = 0.4f;  // 전체 거리 중 이 실린더의 비중
    public float offset = 0f;     // 이중 결합용 옆으로 밀기

    void Update()
    {
        if (myAtom == null || targetAtom == null) return;

        // 1. 방향 및 전체 거리 계산
        Vector3 startPos = myAtom.position;
        Vector3 targetPos = targetAtom.position;
        Vector3 direction = (targetPos - startPos).normalized;
        float totalDistance = Vector3.Distance(startPos, targetPos);

        // 2. 담당할 길이 계산 (비율 적용)
        // 틈새가 벌어지는 것을 방지하기 위해 0.02f 만큼 아주 살짝 더 길게 만듭니다.
        float finalLength = (totalDistance * myRatio) + 0.02f;

        // 3. 이중 결합을 위한 수직(옆) 방향 계산
        Vector3 sideDirection = Vector3.Cross(direction, Vector3.up).normalized;
        if (sideDirection == Vector3.zero)
            sideDirection = Vector3.Cross(direction, Vector3.forward).normalized;

        // 4. 위치 결정: 내 원자에서 내 길이의 절반만큼 전진 + 옆으로 offset
        transform.position = startPos + (direction * (finalLength / 2f)) + (sideDirection * offset);

        // 5. 회전: 상대 원자를 바라보게 함
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
            transform.Rotate(90, 0, 0); // 유니티 실린더 눕히기
        }

        // 6. 크기(Scale) 설정: 굵기는 Thickness, 길이는 finalLength
        // 실린더 기본 높이가 2이므로 길이를 2로 나눕니다.
        transform.localScale = new Vector3(bondThickness, finalLength / 2f, bondThickness);
    }
}