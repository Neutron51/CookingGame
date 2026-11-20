using UnityEngine;
using UnityEngine.UI;

public class Odotaminipeli : MonoBehaviour
{
    public float moveSpeed = 10f;


    public Slider slider;
    public Image sliderFill;

    public Color lowColor = Color.red;
    public Color highColor = Color.green;

    public float perfectValue = 80f;
    public float perfectTolerance = 100f;
    public float overTheLine = 100f;

    private bool hasSucceeded = false;
    private bool hasFailed = false;
    private bool hasStopped = false;

    [SerializeField] private Gamemanager gameManager;

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

        float t = Mathf.InverseLerp(0f, 80f, slider.value);

        Color targetColor = Color.Lerp(lowColor, highColor, t);

        sliderFill.color = Color.Lerp(sliderFill.color, targetColor, Time.deltaTime * 3f);

        GetComponent<Slider>().enabled = true;
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
            gameManager.FinishRecipeStep2();
        }
        else
        {
            hasFailed = true;

            if (currentValue < perfectValue)
            {
                Debug.Log("You Lose! Too Early!");
                gameManager.FinishRecipeStep2();
            }
            else
            {
                Debug.Log("You Lose! Too Late!");
                gameManager.FinishRecipeStep2();
            }
        }
        
    }
}
