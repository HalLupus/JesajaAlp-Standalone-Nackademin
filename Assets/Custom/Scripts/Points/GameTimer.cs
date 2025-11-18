using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float startTime = 60f;   // Starting time in seconds
    public bool startOnAwake = true;

    [Header("Events")]
    public UnityEvent onTimerEnd;   // Trigger when time reaches 0

    private float currentTime;
    private bool isRunning = false;

    void Start()
    {
        if (startOnAwake)
            StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;
            onTimerEnd?.Invoke();
        }

        // Optional: Update UI here
        //Debug.Log($"Time Left: {currentTime:F1}");
    }

    public void StartTimer()
    {
        currentTime = startTime;
        isRunning = true;
    }

    public void AddTime(float amount)
    {
        currentTime += amount;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResumeTimer()
    {
        isRunning = true;
    }

    public float GetTimeRemaining()
    {
        return currentTime;
    }
}
