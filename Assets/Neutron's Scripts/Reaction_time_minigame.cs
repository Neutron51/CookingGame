using UnityEngine;

public class Reaction_time_minigame : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public RectTransform safeZone;
    public float moveSpeed = 100f;

    public RectTransform background;

    public GameObject[] hearts;

    public int maxSuccesses = 3;

    private RectTransform pointerTransform;
    private Vector3 targetPosition;

    private int currentHearts;
    private int successCount = 0;

    private bool hasSucceeded = false;
    private bool hasFailed = false;

    void Start()
    {
        pointerTransform = GetComponent<RectTransform>();
        currentHearts = hearts.Length;

        targetPosition = pointB.position;
    }

    void Update()
    {
        if (hasSucceeded == true)
        {
            return;
        }

        if (hasFailed == true)
        {
            return;
        }

        pointerTransform.position = Vector3.MoveTowards(
            pointerTransform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(pointerTransform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
        }
        else if (Vector3.Distance(pointerTransform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
        }
    }

    public void CheckSuccess()
    {
        if (hasSucceeded == true)
        {
            return;
        }

        if (hasFailed == true)
        {
            return;
        }

        if (RectTransformUtility.RectangleContainsScreenPoint(
            safeZone,
            pointerTransform.position,
            null))
        {
            Debug.Log("Success!");

            successCount++;

            if (successCount >= maxSuccesses)
            {
                WinGame();
                return;
            }

            MoveSafeZone();
        }
        else
        {
            Debug.Log("Fail!");

            LoseHeart();
        }
    }

    void LoseHeart()
    {
        currentHearts--;

        if (currentHearts >= 0)
        {
            hearts[currentHearts].SetActive(false);
        }

        if (currentHearts <= 0)
        {
            LoseGame();
        }
    }

    void MoveSafeZone()
    {
        float halfWidth = background.rect.width / 2f;
        float safeHalfWidth = safeZone.rect.width / 2f;
        float randomX = Random.Range(
                    -halfWidth + safeHalfWidth,
                    halfWidth - safeHalfWidth
                );

        Vector2 newPosition = safeZone.anchoredPosition;

        newPosition.x = randomX;

        safeZone.anchoredPosition = newPosition;

        Debug.Log("Safe zone moved!");
    }

    void WinGame()
    {
        hasFailed = true;

        Debug.Log("MINIGAME COMPLETED!");
    }

    void LoseGame()
    {
        hasFailed = true;

        Debug.Log("MINIGAME FAILED!");
    }
}
