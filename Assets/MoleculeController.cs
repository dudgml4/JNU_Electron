using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeController : MonoBehaviour
{
    public Transform[] actualAtoms; // 실제 원자들
    public Transform targetSetA;    // 목표 A 부모
    public Transform targetSetB;    // 목표 B 부모
    public float moveDuration = 1.5f; // 이동 시간

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) StartCoroutine(MoveRoutine(targetSetA));
        if (Input.GetKeyDown(KeyCode.Alpha2)) StartCoroutine(MoveRoutine(targetSetB));
    }

    IEnumerator MoveRoutine(Transform targetParent)
    {
        float elapsed = 0;
        // 시작 시점의 위치들을 저장
        Vector3[] startPositions = new Vector3[actualAtoms.Length];
        for (int i = 0; i < actualAtoms.Length; i++)
        {
            startPositions[i] = actualAtoms[i].position;
        }

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;

            // 부드러운 가속/감속 효과 (SmoothStep)
            t = t * t * (3f - 2f * t);

            for (int i = 0; i < actualAtoms.Length; i++)
            {
                Vector3 targetPos = targetParent.GetChild(i).position;
                actualAtoms[i].position = Vector3.Lerp(startPositions[i], targetPos, t);
            }
            yield return null;
        }
    }
}
