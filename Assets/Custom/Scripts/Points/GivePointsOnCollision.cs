using UnityEngine;

public class GivePointsOnCollision : MonoBehaviour
{
    public int pointsToGive = 5;

    [Tooltip("Only trigger with this layer")]
    public LayerMask targetLayer; // Use dropdown

    public PointManager pointManager;

    [Tooltip("Time in seconds between triggers")]
    public float cooldownTime = 0.2f; // editable in inspector
    private float lastTriggerTime = -Mathf.Infinity; // track last trigger

    void Start()
    {
        if (pointManager == null)
        {
            pointManager = FindObjectOfType<PointManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is in the selected layer
        if (((1 << other.gameObject.layer) & targetLayer) != 0)
        {
            // Only trigger if enough time has passed
            if (Time.time - lastTriggerTime >= cooldownTime)
            {
                GivePoints();
                lastTriggerTime = Time.time;
            }
        }
    }

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
