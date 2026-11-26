using UnityEngine;

public class LogoPulse : MonoBehaviour
{
   
    [SerializeField] private float pulseScale = 1.2f;

    
  
    [SerializeField] private float pulseSpeed = 1f;

    
    private Vector3 originalScale;

    private void Awake()
    {
      
        originalScale = transform.localScale;
    }

    private void Update()
    {
        
        float wave = Mathf.Sin(Time.time * pulseSpeed * Mathf.PI * 2f);

        
        float t = (wave + 1f) * 0.5f;

        float multiplier = Mathf.Lerp(1f, pulseScale, t);

      
        transform.localScale = originalScale * multiplier;
    }

    private void OnDisable()
    {
       
        transform.localScale = originalScale;
    }
}
