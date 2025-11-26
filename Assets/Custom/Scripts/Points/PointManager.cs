using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int totalPoints;
    public int pointsMultiplier = 1;

    public int highScore;
    public int lastRun;

    [Header("UI")]
    public TMP_Text pointsText;
    public TMP_Text highScoreText;
    public TMP_Text lastRunText;

    void Awake()
    {
        // Load saved values
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        lastRun = PlayerPrefs.GetInt("LastRun", 0);

        totalPoints = 0;

        UpdateUI();
    }

    public void AddPoints(int amount)
    {
        totalPoints += amount * pointsMultiplier;
        UpdateUI();
    }

    // Call this BEFORE reloading the scene
    public void RegisterRun()
    {
        lastRun = totalPoints;

        if (totalPoints > highScore)
        {
            highScore = totalPoints;
        }

        // Save them
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("LastRun", lastRun);
        PlayerPrefs.Save();

        UpdateUI();
    }

    private void UpdateUI()
    {
        if (pointsText != null)
            pointsText.text = "Points: " + totalPoints;

        if (highScoreText != null)
            highScoreText.text = "Highscore: " + highScore;

        if (lastRunText != null)
            lastRunText.text = "Last run: " + lastRun;
    }
}
