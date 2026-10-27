using UnityEngine;

public class Reaction_time_minigame : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform safeZone;
    public float moveSpeed = 100f;

    private RectTransform pointerTransform;
    private Vector3 targetPosition;
    private bool hasSucceeded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasSucceeded)
            return;

        pointerTransform.position = Vector3.MoveTowards(pointerTransform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
        }

        //Add pressing mechanic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckSuccess();
        }
    }

    public void CheckSuccess()
    {
        if (hasSucceeded)
            return;

        if (RectTransformUtility.RectangleContainsScreenPoint(safeZone, pointerTransform.position, null))
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
