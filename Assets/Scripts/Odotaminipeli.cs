using UnityEngine;

public class Odotaminipeli : MonoBehaviour
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
