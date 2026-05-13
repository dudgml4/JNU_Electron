using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MonoCularStructure : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Reference")]
    [SerializeField] private Transform targetTransform;
    [Header("Value")]
    [SerializeField] private float rotateSpeed = 5.0f;
    [SerializeField] private Vector3 direction;
    private Vector2 startPostion;
    private Vector2 mousePosition;
    private Vector3 angle;
    private Quaternion rotation;

    public void OnBeginDrag(PointerEventData eventData)
    {
        mousePosition = GetMousePostion();
        startPostion = mousePosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        mousePosition = GetMousePostion();

        if (mousePosition.x < startPostion.x)
        {
            targetTransform.rotation *= Quaternion.Euler(rotateSpeed * direction);
        }
        else if (mousePosition.x > startPostion.x)
        {
            targetTransform.rotation *= Quaternion.Euler(-rotateSpeed * direction);
        }

        if (mousePosition.y < startPostion.y)
        {
            targetTransform.rotation *= Quaternion.Euler(rotateSpeed * direction);
        }
        else if (mousePosition.y > startPostion.y)
        {
            targetTransform.rotation *= Quaternion.Euler(-rotateSpeed * direction);
        }

        startPostion = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    private Vector3 GetMousePostion()
    {
        Vector3 mousePosition = InputSystem.actions.FindAction("Point").ReadValue<Vector2>();
        Vector3 position = Camera.main.ScreenToViewportPoint(mousePosition);

        return position;
    }
}
