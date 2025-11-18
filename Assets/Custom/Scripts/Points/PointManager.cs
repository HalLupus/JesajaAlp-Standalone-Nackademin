using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int totalPoints;

    [Header("UI")]
    public TMP_Text pointsText;   // Drag your TextMeshPro text object here

    void Awake()
    {
        totalPoints = 0;
        UpdateUI();
    }

    // Function to add points
    public void AddPoints(int amount)
    {
        totalPoints += amount;
        UpdateUI();
    }

    // Update the TextMeshPro text
    private void UpdateUI()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + totalPoints;
        }
        else
        {
            Debug.LogWarning("PointManager: No pointsText assigned!");
        }
    }
}
