using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    public GameTimer timer;
    public TextMeshProUGUI timerText;

    void Update()
    {
        if (timerText != null)
            timerText.text = $"{timer.GetTimeRemaining():F1}s";
    }
}
