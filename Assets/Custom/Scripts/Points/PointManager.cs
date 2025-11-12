using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int totalPoints;

    void Awake()
    {
        totalPoints = 0;
    }

    // Function to add points
    public void AddPoints(int amount)
    {
        totalPoints += amount;
        Debug.Log("Points added: " + amount + " | Total: " + totalPoints);
    }
}
