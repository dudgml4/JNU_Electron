using UnityEngine;

public class Monocule : MonoBehaviour
{
    [Header("Value")]
    [SerializeField] private float scale;
    private Vector3 initPosition;

    private void Awake()
    {
        initPosition = transform.localPosition;
    }

    private void Update()
    {
        Thrilling();
    }

    private void Thrilling()
    {
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
