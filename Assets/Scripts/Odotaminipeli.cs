using UnityEngine;
using UnityEngine.UI;

public class Odotaminipeli : MonoBehaviour
{
    public float tapDistance = 10f;
    public float moveSpeed = 10f;

    public Slider slider;

    private bool hasSucceeded = false;
    private bool hasFailed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.minValue = 0f;
        slider.maxValue = 100f;
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSucceeded == true)
        {
            return;
        }

        if(hasFailed == true)
        {
            return;
        }

        slider.value += moveSpeed * Time.deltaTime;

        if(slider.value <= 0f)
        {
            hasFailed = true;
            Debug.Log("You Lose!");
        }

        if(slider.value >= 100f)
        {
            hasSucceeded = true;
            Debug.Log("You Win!");
        }


    }
    public void ButtonTap()
    {
        if (hasSucceeded == true)
        {
            return;
        }

        if (hasFailed == true)
        {
            return;
        }
    }
}
