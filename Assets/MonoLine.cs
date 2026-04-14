using UnityEngine;

public class MonoLine : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private GameObject monocular1;
    [SerializeField] private GameObject monocular2;

    [Header("Line Setting")]
    [SerializeField] private float sideOffset = 0f;

    [Header("Value")]
    private float epsilon = 1e-4f;

    private void LateUpdate()
    {
        if (monocular1 == null || monocular2 == null) return;

        FitLine();
    }

    private void FitLine()
    {
        Vector3 position1 = monocular1.transform.position;
        Vector3 position2 = monocular2.transform.position;

        Vector3 direction = position2 - position1;
        float length = direction.magnitude;

        if (length < epsilon) return;

        Vector3 centerPos = (position1 + position2) * 0.5f;
        Vector3 lineDirection = direction.normalized;

        transform.up = lineDirection;

        if (Mathf.Abs(sideOffset) > epsilon)
        {
            Vector3 rightDir = Vector3.Cross(lineDirection, Vector3.forward);
            if (rightDir.sqrMagnitude < 0.001f)
                rightDir = Vector3.Cross(lineDirection, Vector3.up);

            transform.position = centerPos + (rightDir.normalized * sideOffset);
        }
        else
        {
            transform.position = centerPos;
        }

        Vector3 currentScale = transform.localScale;
        currentScale.y = length * 0.5f;
        transform.localScale = currentScale;
    }
}