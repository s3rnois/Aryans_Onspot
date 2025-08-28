using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerBoss : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 60f;
    public float normalSpeed = 1.0f;
    public float slowSpeed = 0.5f;
    public float spacePenalty = 1f;
    
    [Header("UI References")]
    public TextMeshProUGUI timerText;
    public Slider timerSlider;
    public Image timerFillImage;
    public TextMeshProUGUI completionText; // New UI element for completion message
    
    [Header("Color Settings")]
    public Color normalColor = Color.red;
    public Color warningColor = Color.yellow;
    public Color criticalColor = Color.red;
    public float warningThreshold = 20f;
    public float criticalThreshold = 10f;
    
    private float currentTime;
    private bool isTimerRunning = true;
    private bool levelCompleted = false;
    private float currentSpeed;
    
    void Start()
    {
        currentTime = startTime;
        currentSpeed = slowSpeed;
        
        // Setup UI if not assigned
        if (timerText == null)
            timerText = GameObject.Find("TimerText")?.GetComponent<TextMeshProUGUI>();
        
        if (timerSlider == null)
            timerSlider = GameObject.Find("TimerSlider")?.GetComponent<Slider>();
        
        if (timerSlider != null)
        {
            timerSlider.minValue = 0;
            timerSlider.maxValue = startTime;
            timerSlider.value = currentTime;
        }
        
        // Hide completion text initially
        if (completionText != null)
        {
            completionText.gameObject.SetActive(false);
        }
        
        UpdateTimerUI();
    }
    
    void Update()
    {
        if (!isTimerRunning || levelCompleted) return;
        
        // Check for WASD input
        bool isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
                       Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
        
        // Set speed based on movement
        currentSpeed = isMoving ? normalSpeed : slowSpeed;
        
        // Apply time deduction
        currentTime -= currentSpeed * Time.deltaTime;
        
        // Check for space bar penalty
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentTime -= spacePenalty;
            Debug.Log($"Space pressed! -{spacePenalty}s");
        }
        
        // Update UI
        UpdateTimerUI();
        
        // Check if timer reached zero
        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isTimerRunning = false;
            TimerEnded();
        }
    }
    
    // This method will be called when player collides with objective
    public void CompleteLevel()
    {
        if (levelCompleted) return; // Prevent multiple calls
        
        levelCompleted = true;
        isTimerRunning = false;
        
        // Show completion message
        if (completionText != null)
        {
            completionText.gameObject.SetActive(true);
            completionText.text = $"Congrats, you saved {currentTime:F1} seconds!";
            
            // Hide normal timer UI
            if (timerText != null) timerText.gameObject.SetActive(false);
            if (timerSlider != null) timerSlider.gameObject.SetActive(false);
        }
        
        Debug.Log($"Level completed! Time remaining: {currentTime:F1}s");
        
        // Optional: Trigger celebration effects, play sound, etc.
    }
    
    void UpdateTimerUI()
    {
        if (levelCompleted) return;
        
        // Update text
        if (timerText != null)
        {
            timerText.text = $"{currentTime:F1}s";
        }
        
        // Update slider
        if (timerSlider != null)
        {
            timerSlider.value = currentTime;
        }
        
        // Update color based on time remaining
        if (timerFillImage != null)
        {
            if (currentTime <= criticalThreshold)
                timerFillImage.color = criticalColor;
            else if (currentTime <= warningThreshold)
                timerFillImage.color = warningColor;
            else
                timerFillImage.color = normalColor;
        }
    }
    
    void TimerEnded()
    {
        Debug.Log("Time's up!");
        // Add your game over logic here
    }
    
    // Public methods
    public void PauseTimer() => isTimerRunning = false;
    public void ResumeTimer() => isTimerRunning = true;
    public void ResetTimer() 
    { 
        currentTime = startTime; 
        isTimerRunning = true;
        levelCompleted = false;
        
        // Reset UI
        if (completionText != null) completionText.gameObject.SetActive(false);
        if (timerText != null) timerText.gameObject.SetActive(true);
        if (timerSlider != null) timerSlider.gameObject.SetActive(true);
        
        UpdateTimerUI();
    }
    
    public float GetCurrentTime() => currentTime;
    public bool IsTimerRunning() => isTimerRunning;
    public bool IsLevelCompleted() => levelCompleted;
    public float GetCurrentSpeed() => currentSpeed;
}