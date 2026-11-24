using UnityEngine;
using UnityEngine.EventSystems;

public class Touchscreenswipe : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private string[] direction = { "left", "right", "down", "up" };
    [SerializeField] private string currentDirection;
    [SerializeField] private float CorrectionAmount;
    private float endDirectionBeforeRounding;
    private float endDirectionAfterRounding;
    private Vector3 startPoint;
    private Vector3 endPoint;
    public string DetectDirectionOfSwipeInput()
    {
        float vectorX = endPoint.x;
        float vectorY = endPoint.y;
        vectorX = Mathf.RoundToInt(vectorX);
        vectorY = Mathf.RoundToInt(vectorY);
        endPoint.x = vectorX;
        endPoint.y = vectorY;
        if (endPoint.x < startPoint.x)
        {
            return direction[0];
        }
        if (endPoint.x > startPoint.x)
        {
            return direction[1];
        }
        if (endPoint.y < startPoint.y)
        {
            return direction[2];
        }
        if (endPoint.y > startPoint.y)
        {
            return direction[3];
        }
        return "none";
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 firstTouchInput = eventData.position;
        startPoint = firstTouchInput;
        Debug.Log("start of drag");
    }
    public void OnDrag(PointerEventData eventData)
    {
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 lastTouchInput = eventData.position;
        endPoint = lastTouchInput;
        currentDirection = DetectDirectionOfSwipeInput();
        Debug.Log(currentDirection);
    }
}
