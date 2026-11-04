using TMPro;
using UnityEngine;

public class PainaMinipeli : MonoBehaviour
{
    public float clickSpeed = 100f;
    public RectTransform safeZone;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public float moveSpeed = 100f;

    private RectTransform safeZoneFill;
    private Vector3 targetPosition;
    private bool hasSucceeded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        safeZoneFill = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSucceeded)
            return;

        safeZoneFill.position = Vector3.MoveTowards(safeZoneFill.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(safeZoneFill.position, pointA.position) < 0.1f)
        {
            targetPosition = pointC.position;
        }
        else if (Vector3.Distance(safeZoneFill.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
        }
    }

    public void CheckSuccess()
    {
        if (hasSucceeded)
            return;

        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, safeZoneFill.position, null))
        {
            Debug.Log("Success!");
            hasSucceeded = true;
        }
        else
        {
            Debug.Log("Fail!");
        }
    }
}

