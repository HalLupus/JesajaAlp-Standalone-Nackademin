using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int totalPoints;
    
    public int pointsMultiplier = 1; //needs to be 1 by defualt, since all gained points are multiplied by this.

    [Header("UI")]
    public TMP_Text pointsText;

    void Awake()
    {
        totalPoints = 0;
        UpdateUI();
    }

    // Function to add points
    public void AddPoints(int amount)
    {
        totalPoints += amount * pointsMultiplier;
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
