using UnityEngine;

public class PointGiver : MonoBehaviour
{
    public int pointsToGive = 5; // The amount this script will add

    // Reference to the PointManager
    public PointManager pointManager;

    void Start()
    {
        // Optionally, automatically find the PointManager in the scene
        if (pointManager == null)
        {
            pointManager = FindObjectOfType<PointManager>();
        }
    }

    // Call this method whenever you want to give points
    public void GivePoints()
    {
        if (pointManager != null)
        {
            pointManager.AddPoints(pointsToGive);
        }
        else
        {
            Debug.LogWarning("PointManager not found!");
        }
    }
}
