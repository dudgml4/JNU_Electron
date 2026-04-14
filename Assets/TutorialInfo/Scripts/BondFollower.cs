using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BondFollower : MonoBehaviour
{
    public Transform atomA;
    public Transform atomB;

    public float bondThickness = 0.2f; // 굵기 0.2 반영
    public float offset = 0f;

    void Update()
    {
        if (atomA != null && atomB != null)
        {
            // 1. 두 원자 사이의 방향과 거리 계산
            Vector3 posA = atomA.position;
            Vector3 posB = atomB.position;
            Vector3 direction = (posB - posA).normalized;
            float distance = Vector3.Distance(posA, posB);

            // 2. 옆으로 밀어낼 방향(수직 벡터) 계산
            // 위쪽 방향(Up)과 결합 방향을 외적해서 옆 방향을 구합니다.
            Vector3 sideDirection = Vector3.Cross(direction, Vector3.up).normalized;
            if (sideDirection == Vector3.zero)
                sideDirection = Vector3.Cross(direction, Vector3.forward).normalized;

            // 3. 최종 위치 결정: 두 원자의 정중앙 + 옆으로 offset만큼 이동
            Vector3 centerPos = (posA + posB) / 2f;
            transform.position = centerPos + (sideDirection * offset);

            // 4. 회전 설정: atomB를 정확히 바라보게 함
            transform.rotation = Quaternion.LookRotation(direction);
            // 유니티 실린더는 세워져 있으므로(Y축이 길음) X축으로 90도 눕혀야 함
            transform.Rotate(90, 0, 0);

            // 5. 크기 설정: 굵기는 입력값, 길이는 두 원자 사이의 거리 (실린더 기본 높이가 2라 /2)
            transform.localScale = new Vector3(bondThickness, distance / 2f, bondThickness);
        }
    }
}