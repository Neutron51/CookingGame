using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Odotaminipeli : MonoBehaviour
{
    public float moveSpeed = 10f;

    public Slider slider;

    public float perfectValue = 80f;
    public float perfectTolerance = 100f;

    private bool hasSucceeded = false;
    private bool hasFailed = false;
    private bool hasStopped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 100f;
        slider.value = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStopped)
        {
            return;
        }

        slider.value += moveSpeed * Time.deltaTime;

        /*if(slider.value <= 100f)
        {
            slider.value = 100f;
            hasFailed = true;
            hasStopped = true;

            Debug.Log("You Lose! Too Late!");
        }*/
    }
    public void ButtonTap()
    {
        if (hasStopped)
        {
            return;
        }

        hasStopped = true;

        float currentValue = slider.value;

        if (Mathf.Abs(currentValue - perfectValue) <= perfectTolerance)
        {
            hasStopped = true;
            Debug.Log("PERFECT SCORE!");
        }
        else
        {
            hasFailed = true;

            if (currentValue < perfectValue)
            {
                Debug.Log("You Lose! Too Early!");
            }
            else
            {
                Debug.Log("You Lose! Too Late!");
            }
        }
        
    }
}
