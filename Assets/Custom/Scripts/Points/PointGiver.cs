using UnityEngine;

public class PointGiver : MonoBehaviour
{
    public int pointsToGive = 5;             // Amount to add
    public string targetLayerName = "Player"; // Only trigger with this layer

    public PointManager pointManager;

    void Start()
    {
        // Automatically find the PointManager in the scene
        if (pointManager == null)
        {
            pointManager = FindObjectOfType<PointManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is on the correct layer
        if (other.gameObject.layer == LayerMask.NameToLayer(targetLayerName))
        {
            GivePoints();
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
