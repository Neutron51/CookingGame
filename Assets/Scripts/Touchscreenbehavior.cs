using UnityEngine;
using UnityEngine.EventSystems;

public class Touchscreenbehavior : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Gamemanager gamemanager;
    [SerializeField] private Transform target;
    [SerializeField] private float goalRotation;
    [SerializeField] private float currentRotations;
    private Vector2 lastDirection;
    private void Update()
    {
        if (currentRotations >= goalRotation)
        {
            gamemanager.FinishRecipeStep();
            Debug.Log("Goal reached, minigame finished");
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (target == null)
            target = transform;
        Vector2 center = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, target.position);
        lastDirection = eventData.position - center;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (target == null)
        {
            return;
        }
        Vector2 center = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera,target.position);
        Vector2 currentDirection = eventData.position - center;
        if (lastDirection.sqrMagnitude < 0.001f || currentDirection.sqrMagnitude < 0.001f)
        {
            return;
        }
        float angle = Vector2.SignedAngle(lastDirection, currentDirection);
        target.Rotate(0f, 0f, angle);
        currentRotations += Mathf.Abs(angle);
        lastDirection = currentDirection;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
