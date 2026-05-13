using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BondLine : MonoBehaviour
{
    public Transform atomA;
    public Transform atomB;
    public float thickness = 0.05f;

    void LateUpdate()
    {
        if (atomA == null || atomB == null) return;

        Vector3 posA = atomA.position;
        Vector3 posB = atomB.position;

        transform.position = (posA + posB) / 2f;
        transform.LookAt(posB);
        transform.Rotate(90, 0, 0);

        float distance = Vector3.Distance(posA, posB);
        transform.localScale = new Vector3(thickness, distance / 2f, thickness);
    }
}
