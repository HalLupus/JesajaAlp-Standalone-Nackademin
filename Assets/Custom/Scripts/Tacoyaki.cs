using UnityEngine;
using System.Collections;

public class Tacoyaki : MonoBehaviour
{
    [Header("Target Object")]
    public GameObject targetObject; // Only triggers when this object enters

    [Header("PointManager Settings")]
    public PointManager pointManager; // Drag your PointManager here
    public int addPointsAmount = 10; // Amount to add if random chooses AddPoints
    public float multiplierDuration = 5f; // How long multiplier lasts
    public int multiplierValue = 2; // The multiplier to apply

    [Header("GameTimer Settings")]
    public GameTimer gameTimer; // Drag your GameTimer here
    public float addTimeAmount = 10f; // Amount of time to add if chosen

    [Header("Effect Display")]
    public EffectDisplay effectDisplay; // Drag your EffectDisplay here

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            int randomChoice = Random.Range(0, 3); // 0, 1, or 2

            switch (randomChoice)
            {
                case 0:
                    if (pointManager != null)
                    {
                        effectDisplay?.ShowMessage($"Points x{multiplierValue} for {multiplierDuration} seconds!");
                        StartCoroutine(TemporaryMultiplier());
                    }
                    else
                    {
                        Debug.LogWarning("RandomTriggerEffect: PointManager not assigned!");
                    }
                    break;

                case 1:
                    if (pointManager != null)
                    {
                        pointManager.AddPoints(addPointsAmount);
                        effectDisplay?.ShowMessage($"You gained {addPointsAmount} points!");
                    }
                    else
                    {
                        Debug.LogWarning("RandomTriggerEffect: PointManager not assigned!");
                    }
                    break;

                case 2:
                    if (gameTimer != null)
                    {
                        gameTimer.AddTime(addTimeAmount);
                        effectDisplay?.ShowMessage($"+{addTimeAmount} seconds added!");
                    }
                    else
                    {
                        Debug.LogWarning("RandomTriggerEffect: GameTimer not assigned!");
                    }
                    break;
            }

            // Destroy the object after triggering
            Debug.Log("RandomTriggerEffect: Triggered object destroyed.");
            Destroy(gameObject);
        }
    }

    private IEnumerator TemporaryMultiplier()
    {
        int originalMultiplier = pointManager.pointsMultiplier;
        pointManager.pointsMultiplier = multiplierValue;

        yield return new WaitForSeconds(multiplierDuration);

        pointManager.pointsMultiplier = originalMultiplier;
        Debug.Log("RandomTriggerEffect: Points multiplier reset to original value.");
    }
}
